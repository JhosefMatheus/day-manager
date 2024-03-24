using backend.Attributes;
using backend.Exceptions.Http;
using backend.Models;
using backend.Responses.Token;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers;

[ApiController]
[Route("token")]
public class TokenController : ControllerBase
{
    private readonly TokenService tokenService;

    public TokenController(TokenService tokenService)
    {
        this.tokenService = tokenService;
    }

    [HttpGet("verify")]
    public ActionResult Verify([FromHeader] string authorization)
    {
        try
        {
            this.tokenService.decodeToken(authorization);

            DecodeTokenResponse decodeTokenResponse = new DecodeTokenResponse("Token autenticado com sucesso.", RequestVariant.Success);

            return Ok(decodeTokenResponse.ToObject());
        }
        catch (ArgumentNullException)
        {
            throw new UnauthorizedRequestException("Token inválido.", RequestVariant.Warning);
        }
        catch (ArgumentException)
        {
            throw new UnauthorizedRequestException("Token inválido.", RequestVariant.Warning);
        }
        catch (SecurityTokenDecryptionFailedException)
        {
            throw new UnauthorizedRequestException("Token inválido.", RequestVariant.Warning);
        }
        catch (SecurityTokenException)
        {
            throw new UnauthorizedRequestException("Token inválido.", RequestVariant.Warning);
        }
    }
}