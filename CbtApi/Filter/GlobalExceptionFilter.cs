using CbtApi.Core.Models;
using CbtApi.Core.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CbtApi.Utility.Filter
{
    public static class GlobalExceptionFilter  
    {
        public static object Json { get; private set; }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, Serilog.ILogger logger)
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

                            
                            logger.Information($"Something went wrong: {contextFeature.Error}");

                         

                            if (contextFeature.Error.GetType() == typeof(ProcessException))
                            {

                                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel<object>(null, false, contextFeature.Error.Message)));

                            }
                            else
                            {

                                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel<object>(null, false, "Server Error")));

                            }
                        }

                    });
                });
            }

       
    }
}
