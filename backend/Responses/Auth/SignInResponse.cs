using backend.Models;

namespace backend.Responses.Auth;

public class SignInResponse : BaseResponse
{
    public string Token { get; }
    public UserWithoutPassword User { get; }

    public SignInResponse(
        string message,
        string token,
        RequestVariant variant,
        UserWithoutPassword user) : base(message, variant)
    {
        this.Token = token;
        this.User = user;
    }

    public override object ToObject()
    {
        return new
        {
            message = base.Message,
            token = this.Token,
            variant = base.Variant.ToString(),
            user = this.User.ToObject()
        };
    }
}