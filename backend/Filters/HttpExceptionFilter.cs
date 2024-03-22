using backend.Exceptions.Http;
using backend.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Filters;

public class HttpExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is BaseHttpException httpException)
        {
            context.Result = new ObjectResult(httpException.ToObject())
            {
                StatusCode = httpException.Status
            };

            context.ExceptionHandled = true;

            HttpRequest request = context.HttpContext.Request;

            if (httpException.Status == 500)
            {
                RequestLog.Log(httpException, request);
            }
        }
    }
}