using backend.Models;

namespace backend.Exceptions.Http;

public class BaseHttpException : BaseException
{
    public int Status { get; }
    public RequestVariant Variant { get; }

    public BaseHttpException(string message, int status, RequestVariant variant) : base(message)
    {
        this.Status = status;
        this.Variant = variant;
    }
}