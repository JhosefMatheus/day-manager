using backend.DTO.Auth;
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
        throw new Exception("testando log");

        SignInResponse signInResponse = this.authService.SignIn(signInDTO);

        return Ok(signInResponse.ToObject());
    }
}