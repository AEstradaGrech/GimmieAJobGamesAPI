using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Domain.Contracts;
using GajGamesServiceRouter.Extensions;
using GimmieAJobGamesAPI.Extensions;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Authorization")
                    .AllowCredentials());
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            var connectionString = Environment.GetEnvironmentVariable("ConnectionString") ??
                                   Configuration["DbConnectionString"];

            StaticStrings.ConnectionString = connectionString;

            services.AddDbContext<GAJDbContext>(options => options.UseMySql(StaticStrings.ConnectionString));

            services.RegisterServices()
                    .SetAuthorizationPolicies()
                    .ConfigureConsul(Configuration);

            var cert = new X509Certificate2(Path.Combine(".", "GajCert.pfx"), "gajgames");

            if (cert != null)
                Console.WriteLine("<<< CERT FOUND >>>");

            var key = new X509SecurityKey(cert);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
            
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidateAudience = false,                                                                                
                    ValidIssuer = "http://gaj-ids4"
                };
            });
        
            

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
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy")
               .HandleMigrationsAndSeedData()
               .UseHttpsRedirection()
               .UseAuthentication()
               .UseMvc()               
               .ConfigureGlobalExceptionHandler()
               .UseSwagger()
               .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GAJ Games API");});            
        }
    }
}
