using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CbtApi.Authorization;
using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models;
using CbtApi.Infrastructure.Context;
using CbtApi.Infrastructure.Entities;
using CbtApi.Utility;
using CbtApi.Utility.Filter;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.Net.Http.Headers;
using Serilog;

namespace CbtApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webhostEnv)
        {
            Configuration = configuration;
            WebHostEnvironment = webhostEnv;

        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            var AllowCorsForList = Configuration.GetSection("AllowCorsForList").Value.Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(AllowCorsForList)
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .WithExposedHeaders("Content-Disposition", "Content-Length"); ;
                });
            });

            services.AddControllers( options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });

            var identyOptions = new IdentityOptions();
            Configuration.GetSection("IdentityOptions").Bind(identyOptions);


            services.AddHttpContextAccessor();

            services.AddHttpClient("IDPClient", client =>
            {
                client.BaseAddress = new Uri(identyOptions.Authority);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

           


            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
             .AddIdentityServerAuthentication(options =>
             {
                 options.Authority = identyOptions.Authority;
                 options.ApiName = identyOptions.CbtApiName;
                 options.ApiSecret = identyOptions.CbtApiSecret;
             });


            services.RegisterDB(Configuration, WebHostEnvironment);

            services.RegisterAuthorization();

            services.RegisterCoreService(Configuration);

            services.ResiterLogger(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger, ISeederRepoistory seederRepo)
        {
            if (env.IsDevelopment())
            {
                seederRepo.Seed();
                app.UseDeveloperExceptionPage();

                IdentityModelEventSource.ShowPII = true;
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
