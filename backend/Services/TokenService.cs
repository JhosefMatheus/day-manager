using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Models;
using backend.Responses.Token;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services;

public class TokenService
{
    private readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string generateToken(UserWithoutPassword user)
    {
        Claim[] claims =
        [
            new Claim("id", user.Id.ToString()),
            new Claim("name", user.Name),
            new Claim("login", user.Login),
            new Claim("createdAt", user.CreatedAt.ToString()),
            new Claim("updatedAt", user.UpdatedAt.ToString()),
            new Claim("deletedAt", user.DeletedAt.ToString())
        ];

        SigningCredentials credentials = this.getJwtCredentials();

        DateTime expiration = DateTime.UtcNow.AddDays(2);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }

    private SigningCredentials getJwtCredentials()
    {
        string jwtSecret = this.configuration.GetValue<string>("JwtSecret");

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        return credentials;
    }

    public ClaimsPrincipal decodeToken(string token)
    {
        string tokenWithoutBearer = token.Replace("Bearer ", "");

        SigningCredentials credentials = this.getJwtCredentials();

        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = credentials.Key
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        SecurityToken securityToken;

        ClaimsPrincipal claims = tokenHandler
            .ValidateToken(tokenWithoutBearer, tokenValidationParameters, out securityToken);

        return claims;
    }
}