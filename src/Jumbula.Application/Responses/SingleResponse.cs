namespace Jumbula.Application.Responses;
public class SingleResponse<T>
{
    public T? Result { get; set; }
    public ResponseStatus Status { get; set; }
    public string Message { get; set; }

    private SingleResponse() { }


    /// <summary>
    /// Use this constructor for failure responses
    /// </summary>
    /// <param name="status">the failure reason</param>
    public SingleResponse(ResponseStatus status, string message)
    {
        Status = status;
        Message = message;
    }

    public static SingleResponse<T> Success(T result)
    {
        return new SingleResponse<T> { Status = ResponseStatus.Success, Result = result, Message = "" };
    }

    public static SingleResponse<T> Success(T result, string message)
    {
        return new SingleResponse<T> { Status = ResponseStatus.Success, Result = result, Message = message };
    }

    public static SingleResponse<T> Failed(ResponseStatus status, string message)
    {
        return new SingleResponse<T> { Status = status, Result = default, Message = message };
    }


    public static implicit operator SingleResponse<T>(T result)
    {
        return Success(result);
    }

    public static implicit operator SingleResponse<T>(ResponseStatus status)
    {
        return Failed(status, string.Empty);
    }

    public static implicit operator SingleResponse<T>(string message)
    {
        return Failed(ResponseStatus.Failed, message);
    }

    public static implicit operator SingleResponse<T>(Tuple<ResponseStatus, string> value)
    {
        return Failed(value.Item1, value.Item2);
    }
}
