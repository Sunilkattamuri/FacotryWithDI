using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAppApi
{
    public class HttpExceptionResponseFilter : IActionFilter
    {
        private readonly ILogger<HttpExceptionResponseFilter> _logger;
        public HttpExceptionResponseFilter(ILogger<HttpExceptionResponseFilter> logger)
        {
            _logger = logger;
        }

      
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is Exception exception)
            {
                _logger.LogError(exception.StackTrace);
                context.Result = new ObjectResult(exception.StackTrace)
                {
                    StatusCode = 500,
                };
                context.ExceptionHandled = true;
               
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
