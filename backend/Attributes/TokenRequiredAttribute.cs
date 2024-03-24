using System.Security.Claims;
using backend.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class TokenRequiredAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        TokenService tokenService = context.HttpContext.RequestServices.GetService<TokenService>();

        string authorization = context.HttpContext.Request.Headers.Authorization;

        ClaimsPrincipal claims = tokenService.decodeToken(authorization);

        claims.Claims.ToList().ForEach((Claim c) =>
        {
            
        });
    }
}