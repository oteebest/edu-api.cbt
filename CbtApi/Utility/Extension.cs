using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Managers;
using CbtApi.Core.Models;
using CbtApi.Infrastructure.Entities;
using CbtApi.Infrastructure.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbtApi.Utility
{
    public static class Extension
    {
        public static void RegisterCoreService(this IServiceCollection services, IConfiguration config)
        {

            services.Configure<IdentityOptions>(config.GetSection("IdentityOptions"));
            services.Configure<CBTClientIdentityOptions>(config.GetSection("CBTClientIdentityOptions"));

            #region Managers

            services.AddScoped<IAssessmentManager, AssessmentManager>();
          
            #endregion



            #region Repository
            services.AddScoped<IAssessmentRepository, AssessmentRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRespository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRespository>();

            #endregion



            #region Service

            #endregion


        

        }

        public static void ResiterLogger(this IServiceCollection services, IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
       .ReadFrom.Configuration(config)
       .Enrich.FromLogContext()
       .CreateLogger();

            services.AddSingleton(Log.Logger);



        }

        public static void RegisterDB(this IServiceCollection services)
        {

        }

        //public static IWebHost MigrateDb(this IWebHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        try
        //        {
        //            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //            context.Database.Migrate();

        //        }
        //        catch (Exception ex)
        //        {
        //            //var logger = host.Services.GetRequiredService<ILogger<DataEntities>>();
        //            //logger.LogError(ex, "An error occurred migrating the the DB.");
        //        }
        //    }
        //    return host;
        //}
    }
}
