namespace Jumbula.Application.Responses;

public class JustResponse
{
    public ResponseStatus Status { get; set; }
    public string Message { get; set; }

    public static JustResponse Success()
    {
        return new JustResponse { Status = ResponseStatus.Success, Message = "" };
    }

    public static JustResponse Success(string message)
    {
        return new JustResponse { Status = ResponseStatus.Success, Message = message };
    }

    public static JustResponse Failed(ResponseStatus status, string message)
    {
        return new JustResponse { Status = status, Message = message };
    }

    public static JustResponse Failed(ResponseStatus status)
    {
        return new JustResponse { Status = status, Message = "" };
    }

    public static implicit operator JustResponse(ResponseStatus status)
    {
        if (status == ResponseStatus.Success)
            return Success();
        else
            return Failed(status);
    }
}
