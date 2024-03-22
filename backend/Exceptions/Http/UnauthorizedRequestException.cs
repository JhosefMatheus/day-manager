using backend.Models;

namespace backend.Exceptions.Http;

public class UnauthorizedRequestException : BaseHttpException
{
    public UnauthorizedRequestException(string message, RequestVariant requestVariant) : base(message, 401, requestVariant)
    {
        
    }
}