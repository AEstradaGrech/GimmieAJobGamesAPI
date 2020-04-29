using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
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
    }
}
