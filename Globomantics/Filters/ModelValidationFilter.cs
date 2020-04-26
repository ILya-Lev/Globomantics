using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Globomantics.Filters
{
    public class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ViewResult()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ViewData = (context.Controller as Controller).ViewData,
                    TempData = (context.Controller as Controller).TempData
                };
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
