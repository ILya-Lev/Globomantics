using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Globomantics.Filters
{
    public class RateExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is TimeoutException timeout)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status504GatewayTimeout);
            }
        }
    }
}
