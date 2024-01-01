using Atolla.Api.Framework.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atolla.Api.Framework.ActionFilters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();


                var response = new AtollaAppResponse();
                response.ErrorMessage = string.Concat(errors);
                response.HasError = true;
                response.Message = string.Concat(errors);
                Serilog.Log.Error("Model is not Valid");
                context.Result = new JsonResult(response)
                {
                    StatusCode = 200
                };
            }
        }
    }
}
