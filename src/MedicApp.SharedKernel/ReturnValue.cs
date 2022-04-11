namespace MedicApp.SharedKernel;

public class ReturnValue : ValueObject<ReturnValue>, IReturnValue
{
    public ReturnValue(string message, bool hasError = false)
    {
        Message = message;
        HasError = hasError;
    }

    [JsonProperty(PropertyName = "message")]
    public string Message { get; private set; } = string.Empty;

    [JsonProperty(PropertyName = "isError")]
    public bool HasError { get; private set; }

    public void SetErrorMessage(string message)
    {
        Message = message;
        HasError = true;
    }
}

public class ReturnValue<T> : ValueObject<ReturnValue<T>>, IReturnValue where T : class
{
    public bool HasError { get; private set; } = false;

    [JsonProperty(PropertyName = "value")]
    public T? Value { get; set; }

    public ReturnValue SetErrorMessage(string message)
    {
        return new ReturnValue(message, true);
    }
}
