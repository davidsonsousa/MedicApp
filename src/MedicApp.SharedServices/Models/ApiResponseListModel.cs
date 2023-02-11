namespace MedicApp.SharedServices.Models;

public class ApiResponseListModel<T>
{
    public bool HasError { get; set; } = false;

    public int Count { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;

    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
}
