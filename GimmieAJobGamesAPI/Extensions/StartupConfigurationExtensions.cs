using System;
using System.IO;
using System.Reflection;
using Domain.Contracts;
using GimmieAJobGamesAPI.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace GimmieAJobGamesAPI.Extensions
{
    public static class StartupConfigurationExtensions
    {
        public static IApplicationBuilder SetDatabase(this IApplicationBuilder app, string connectionString)
        {
            using(var connection = new MySqlConnection(connectionString))
            {                               
                try
                {
                    var query = File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory())}/Infrastructure/DbScripts/DbDesign.sql");

                    connection.Open();

                    var cmd = new MySqlCommand();

                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    Console.Write($"{ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }

            return app;
        }

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
    }
}
