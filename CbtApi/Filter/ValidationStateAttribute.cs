using CbtApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Utility.Filter
{
  
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Validates Model automaticaly 
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Select(u => u.Errors);

             
                List<string> errorList = new List<string>();

                foreach(var error in errors)
                {
                    if(error.FirstOrDefault() != null)
                    {
                        errorList.Add(error.FirstOrDefault().ErrorMessage);
                    }
                    
                }
                
                context.Result = new BadRequestObjectResult(new ResponseModel<string>(null,false,string.Join(',', errorList.ToArray() ) ) );
            }
        }


    }
}
