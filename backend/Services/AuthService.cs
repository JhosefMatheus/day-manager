using backend.DTO.Auth;
using backend.Exceptions.Http;
using backend.Models;
using backend.Responses.Auth;

namespace backend.Services;

public class AuthService
{
    private readonly DayContext context;
    private readonly HashService hashService;
    private readonly TokenService tokenService;

    public AuthService(DayContext context, HashService hashService, TokenService tokenService)
    {
        this.context = context;
        this.hashService = hashService;
        this.tokenService = tokenService;
    }

    public SignInResponse SignIn(SignInDTO signInDTO)
    {
        try
        {
            string login = signInDTO.Login;
            string password = signInDTO.Password;
            string hashedPassword = this.hashService.Sha256(password);

            UserModel user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == hashedPassword);

            if (user == null)
            {
                throw new UnauthorizedRequestException("Login ou senha inválidos.", RequestVariant.Warning);
            }

            UserWithoutPassword userWithoutPassword = new UserWithoutPassword(user);

            string token = this.tokenService.generateToken(userWithoutPassword);

            SignInResponse signInResponse = new SignInResponse(
                "Usuário autenticado com sucesso.",
                token,
                RequestVariant.Success,
                userWithoutPassword
            );

            return signInResponse;
        }
        catch (Exception)
        {
            throw;
        }
    }
}