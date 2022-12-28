namespace MedicApp.SharedKernel;

public class Result : ValueObject<Result>, IResult
{
    public Result(string message, bool hasError = false)
    {
        Message = message;
        HasError = hasError;
    }

    public string Message { get; private set; } = string.Empty;

    public bool HasError { get; private set; }

    public void SetErrorMessage(string message)
    {
        Message = message;
        HasError = true;
    }
}

public class Result<T> : ValueObject<Result<T>>, IResult where T : class
{
    public bool HasError { get; private set; } = false;

    public string Message { get; private set; } = string.Empty;

    public T? Value { get; set; }

    public void SetErrorMessage(string message)
    {
        HasError = true;
        Message = message;
    }
}
