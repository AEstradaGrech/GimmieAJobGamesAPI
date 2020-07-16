using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Consul;
using Domain.Contracts;
using Domain.Contracts.Mappers;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using GimmieAJobGamesAPI.Services;
using GimmieAJobGamesAPI.Services.MapperServices;
using Infrastructure.ConsulServiceRegistration;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Infrastructure.Specifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

namespace GimmieAJobGamesAPI.Extensions
{
    public static class StartupConfigurationExtensions
    {
       
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {            
            return services.RegisterRepositories()
                           .RegisterMgmtServices()
                           .RegisterMapperServices()
                           .RegisterFactories();
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IStudiosRepository, StudiosRepository>();
            services.AddScoped<IGameStudioRepository, GameStudioRepository>();
            services.AddScoped<IGamePromotionRepository, GamePromotionRepository>();
            services.AddScoped<IPromotionsRepository, PromotionsRepository>();

            return services;
        }

        private static IServiceCollection RegisterMapperServices(this IServiceCollection services)
        {
            services.AddScoped<IStudiosMapperService, StudiosMapperService>();
            services.AddScoped<IGamePromotionsMapperService, GamePromotionsMapperService>();
            services.AddScoped<IGamesMapperService, GamesMapperService>();

            return services;
        }

        private static IServiceCollection RegisterMgmtServices(this IServiceCollection services)
        {
            services.AddScoped<IGamesMgmtService, GamesMgmtService>();
            services.AddScoped<IGamePromotionsMgmtService, GamePromotionsMgmtService>();
            services.AddScoped<IStudiosMgmtService, StudiosMgmtService>();
            
            return services;
        }

        private static IServiceCollection RegisterFactories(this IServiceCollection services)
        {
            services.AddScoped<IGamesSpecificationFactory, GamesSpecificationFactory>();
            services.AddScoped<IGameSortingParamExpressionFactory, GameSortingParamExpressionFactory>();
            services.AddScoped<IStudioSortingParamExpressionFactory, StudioSortingParamExpressionFactory>();

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

        public static IApplicationBuilder ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetail()
                        {

                            StatusCode = context.Response.StatusCode,
                            Message = $"Internal Server Error. Exception Message :: {contextFeature.Error}"

                        }.ToString());
                    }
                });
            });

            return app;
        }

        public static IServiceCollection ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceConfig = GetServiceConfig(configuration);

            return services.RegisterConsulService(serviceConfig);
        }

        /// <summary>
        /// read the configuration required for service discovery from environment variables,
        /// that were passed through the docker-compose.override.yml file.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ServiceConfig GetServiceConfig(this IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            return new ServiceConfig
            {
                ServiceDiscoveryAddress = configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress"),
                ServiceAddress = configuration.GetValue<Uri>("ServiceConfig:serviceAddress"),
                ServiceName = configuration.GetValue<string>("ServiceConfig:serviceName"),
                ServiceId = configuration.GetValue<string>("ServiceConfig:serviceId")
            };
        }
        /// <summary>
        ///  register configuration and hosted service with Consul dependencies
        ///  to dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceConfig"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterConsulService(this IServiceCollection services, ServiceConfig serviceConfig)
        {
            if (serviceConfig == null)
                throw new ArgumentNullException(nameof(serviceConfig));

            var consulClient = CreateConsulClient(serviceConfig);

            services.AddSingleton(serviceConfig);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
            services.AddSingleton<IConsulClient, ConsulClient>(s => consulClient);

            return services;
        }

        private static ConsulClient CreateConsulClient(ServiceConfig serviceConfig)
        {
            return new ConsulClient(config =>
            {
                config.Address = serviceConfig.ServiceDiscoveryAddress;
            });
        }

    }
}
