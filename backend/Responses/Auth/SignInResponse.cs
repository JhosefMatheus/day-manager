using backend.Models;

namespace backend.Responses.Auth;

public class SignInResponse : BaseResponse
{
    public string Token { get; }
    public RequestVariant RequestVariant { get; }
    public UserWithoutPassword User { get; }

    public SignInResponse(
        string message,
        string token,
        RequestVariant requestVariant,
        UserWithoutPassword user) : base(message)
    {
        this.Token = token;
        this.RequestVariant = requestVariant;
        this.User = user;
    }

    public override object ToObject()
    {
        return new
        {
            message = base.Message,
            token = this.Token,
            variant = this.RequestVariant.ToString(),
            user = this.User.ToObject()
        };
    }
}