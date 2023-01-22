namespace MedicApp.SharedServices.Models;

public class ApiResponseItemModel<T>
{
    public bool HasError { get; set; } = false;

    public DateTime Timestamp { get; set; } = DateTime.Now;

    public T? Item { get; set; }
}
