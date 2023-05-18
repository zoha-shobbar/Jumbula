namespace Jumbula.Application.Responses;
public class ListResponse<T>
{
    public IQueryable<T>? Result { get; set; }
    public ResponseStatus Status { get; set; }
    public string Message { get; set; }


    private ListResponse() { }

    /// <summary>
    /// Use this constructor for success responses
    /// </summary>
    /// <param name="result">the result value</param>
    public ListResponse(IQueryable<T> result)
    {
        Result = result;
        Status = ResponseStatus.Success;
        Message = string.Empty;
    }

    /// <summary>
    /// Use this constructor for failure responses
    /// </summary>
    /// <param name="status">the failure reason</param>
    public ListResponse(ResponseStatus status)
    {
        Status = status;
    }

    /// <summary>
    /// Use this constructor for failure responses
    /// </summary>
    /// <param name="status">the failure reason</param>
    public ListResponse(ResponseStatus status, string message)
    {
        Status = status;
        Message = message;
    }

    public static ListResponse<T> Success(IQueryable<T> result)
    {
        return new ListResponse<T> { Status = ResponseStatus.Success, Result = result };
    }

    public static ListResponse<T> Success(IQueryable<T> result, string message)
    {
        return new ListResponse<T> { Status = ResponseStatus.Success, Result = result, Message = message };
    }

    public static ListResponse<T> Failed(ResponseStatus status, string message)
    {
        return new ListResponse<T> { Status = status, Result = null, Message = message };
    }

    public static ListResponse<T> Failed(ResponseStatus status)
    {
        return new ListResponse<T> { Status = status, Result = null, Message = string.Empty };
    }

    public static implicit operator ListResponse<T>(ResponseStatus value)
    {
        return Failed(value, string.Empty);
    }

    public static implicit operator ListResponse<T>(string message)
    {
        return Failed(ResponseStatus.Failed, message);
    }

    public static implicit operator ListResponse<T>(Tuple<ResponseStatus, string> value)
    {
        return Failed(value.Item1, value.Item2);
    }
}

