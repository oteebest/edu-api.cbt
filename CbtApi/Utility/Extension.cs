using CbtApi.Authorization;
using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Interface.IValidator;
using CbtApi.Core.Managers;
using CbtApi.Core.Models;
using CbtApi.Infrastructure.Context;
using CbtApi.Infrastructure.Entities;
using CbtApi.Infrastructure.Repository;
using CbtApi.Infrastructure.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddScoped<IQuestionManager, QuestionManager>();
            services.AddScoped<IPredefindDataManager, PredefindDataManager>();

            #endregion

            #region Validators
            services.AddScoped<IAssessmentValidator, AssessmentValidator>();
            services.AddScoped<IQuestionValidator, QuestionValidator>();
            #endregion

            #region Repository
            services.AddScoped<IAssessmentRepository, AssessmentRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISeederRepoistory, SeederRepoistory>();
            services.AddScoped<IPredefinedDataRespository, PredefinedDataRespository>();

            #endregion



            #region Service

            #endregion


        }

        public static void RegisterDB(this IServiceCollection services, IConfiguration config,IWebHostEnvironment webHost)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultContext"));

                if(!webHost.IsProduction())
                {
                    options.EnableSensitiveDataLogging(true);
                }
                
            });
        }
        public static void RegisterAuthorization(this IServiceCollection services)
        {

            services.AddScoped<IAuthorizationHandler, MustBeAssessmentOwnerHandler>();

            services.AddScoped<IAuthorizationHandler, MustBeQuestionOwnerHandler>();

            services.AddAuthorization(authorizationOptions =>
            {

                authorizationOptions.AddPolicy(
                   "MustBeAssessmentOwner",
                   policyBuilder =>
                   {
                       policyBuilder.RequireAuthenticatedUser();
                       policyBuilder.AddRequirements(
                             new MustBeAssessmentOwnerRequirement());
                   });

                authorizationOptions.AddPolicy(
                  "MustBeQuestionOwner",
                  policyBuilder =>
                  {
                      policyBuilder.RequireAuthenticatedUser();
                      policyBuilder.AddRequirements(
                            new MustBeQuestionOwnerRequirement());
                  });
            });



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
