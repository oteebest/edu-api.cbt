using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CbtApi.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CbtApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile($"appsettings.{environment}.json", true, true)
                                 .Build();


            var services = new ServiceCollection();

            services.ResiterLogger(configuration);

            var provider = services.BuildServiceProvider();

            var log = provider.GetService<Serilog.ILogger>();


            try
            {
                log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
