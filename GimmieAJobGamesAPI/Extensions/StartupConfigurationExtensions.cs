using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Domain.Contracts;
using GimmieAJobGamesAPI.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace GimmieAJobGamesAPI.Extensions
{
    public static class StartupConfigurationExtensions
    {
       
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<IDAOFactory, MySqlDAOFactory>(f => new MySqlDAOFactory(new GAJGamesDbContext()));

            //services.AddScoped<ISqlQueryService, SqlQueryService>();
            //var domainAssembly = Assembly.Load(new AssemblyName(nameof(Domain)));
            //var apiAssembly = Assembly.Load(new AssemblyName(nameof(GimmieAJobGamesAPI)));

            //services.AddScoped<typeof(IRepository<*,*>, Repository<,>)
            //        .Scan(scan => scan.FromAssemblies(apiAssembly, domainAssembly)
            //                          .AddClasses()
            //                          .AsMatchingInterface());

            return services;
        }

        public static IApplicationBuilder HandleMigrationsAndSeedData(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GAJDbContext>();

                context.Database.Migrate();

                if (!context.Database.GetPendingMigrations().Any())
                    context.SeedData();
            }

            return app;
        }
    }
}
