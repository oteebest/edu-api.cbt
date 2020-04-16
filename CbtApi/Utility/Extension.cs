using CbtApi.Core.Models;
using CbtApi.Infrastructure.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
