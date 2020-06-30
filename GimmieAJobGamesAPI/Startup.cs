using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts;
using GimmieAJobGamesAPI.Extensions;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace GimmieAJobGamesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Cors",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyOrigin());
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            StaticStrings.ConnectionString = Configuration["DbConnection"];

            services.AddDbContext<GAJDbContext>(options => options.UseMySql(StaticStrings.ConnectionString));

            services.RegisterServices();

            //services.Scan(scan => scan.FromAssembliesOf())

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "GAJ Games API", Version = "v1", });                
            });
          
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

               // app.SetDatabase(Configuration["DbConnection"]);
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.HandleMigrationsAndSeedData()
               .UseHttpsRedirection()
               .UseMvc()
               .ConfigureGlobalExceptionHandler()
               .UseSwagger()
               .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GAJ Games API");});            
        }
    }
}
