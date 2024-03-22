using backend.DTO.Auth;
using backend.Exceptions.Http;
using backend.Models;
using backend.Responses.Auth;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService authService;

    public AuthController(AuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("sign-in")]
    public ActionResult SignIn([FromBody] SignInDTO signInDTO)
    {
        try
        {
            SignInResponse signInResponse = this.authService.SignIn(signInDTO);

            return Ok(signInResponse.ToObject());
        }
        catch (UnauthorizedRequestException e)
        {
            return Unauthorized(new { message = e.Message, variant = e.Variant.ToString() });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}