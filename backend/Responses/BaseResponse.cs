namespace backend.Responses;

public class BaseResponse
{
    public string Message { get; }

    public BaseResponse(string message)
    {
        this.Message = message;
    }

    public virtual object ToObject()
    {
        return new { message = this.Message };
    }
}