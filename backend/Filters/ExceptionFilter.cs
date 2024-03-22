using backend.Log;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Filters;

public class ExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is Exception exception)
        {
            context.Result = new ObjectResult(GenerateResponseBody(exception))
            {
                StatusCode = 500,
            };

            context.ExceptionHandled = true;

            HttpRequest request = context.HttpContext.Request;

            RequestLog.Log(exception, request);
        }
    }

    private static object GenerateResponseBody(Exception exception)
    {
        string message = "Erro inesperado no servidor.";

        if (exception.Message != null)
        {
            message += " " + exception.Message;
        }

        return new
        {
            message,
            variant = RequestVariant.Error.ToString(),
        };
    }
}