using backend.Models;
using backend.Responses;

namespace backend.Responses.Token;

public class DecodeTokenResponse : BaseResponse
{
    public DecodeTokenResponse(string message, RequestVariant variant) : base(message, variant)
    {
        
    }
}