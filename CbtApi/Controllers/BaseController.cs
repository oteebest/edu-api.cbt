using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbtApi.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CbtApi.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {


        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {


            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Select(u => u.Errors);


                List<string> errorList = new List<string>();

                foreach (var error in errors)
                {
                    if (error.FirstOrDefault() != null)
                    {
                        errorList.Add(error.FirstOrDefault().ErrorMessage);
                    }

                }

                context.Result = new BadRequestObjectResult(new ResponseModel<string>(null, false, string.Join(',', errorList.ToArray())));
            }
            base.OnActionExecuting(context);


        }
    }
}