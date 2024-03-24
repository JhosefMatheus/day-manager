using backend.Models;

namespace backend.Responses;

public class BaseResponse
{
    public string Message { get; }
    public RequestVariant Variant { get; }

    public BaseResponse(string message, RequestVariant variant)
    {
        this.Message = message;
        this.Variant = variant;
    }

    public virtual object ToObject()
    {
        return new
        {
            message = this.Message,
            variant = this.Variant.ToString(),
        };
    }
}