namespace MedicApp.SharedServices.Models;

public class ApiResponseModel
{
    public bool HasError { get; set; }

    public string Message { get; private set; }

    public DateTime Timestamp { get; set; }

    public ApiResponseModel(string message, bool hasError = false)
    {
        Message = message;
        HasError = hasError;
        Timestamp = DateTime.Now;
    }
}
