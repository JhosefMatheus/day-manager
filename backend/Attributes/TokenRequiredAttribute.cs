using System.Security.Claims;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace backend.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class TokenRequiredAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            TokenService tokenService = context.HttpContext.RequestServices.GetService<TokenService>();

            StringValues authorization = context.HttpContext.Request.Headers.Authorization.ToString();

            UserWithoutPassword user = tokenService.decodeToken(authorization);

            context.HttpContext.Items["user"] = user;
        }
        catch (ArgumentNullException e)
        {
            context.Result = this.GenerateResponseBody(e);
        }
        catch (ArgumentException e)
        {
            context.Result = this.GenerateResponseBody(e);
        }
        catch (SecurityTokenDecryptionFailedException e)
        {
            context.Result = this.GenerateResponseBody(e);
        }
        catch (SecurityTokenException e)
        {
            context.Result = this.GenerateResponseBody(e);
        }
    }

    private ObjectResult GenerateResponseBody(Exception exception)
    {
        string message = "Token inválido.";

        if (exception.Message != null)
        {
            message += " " + exception.Message;
        }

        return new ObjectResult(new
        {
            message,
            variant = RequestVariant.Error.ToString(),
        })
        {
            StatusCode = 401,
        };
    }
}