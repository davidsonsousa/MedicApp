namespace MedicApp.SharedKernel;

public abstract class ResponseBase<T> where T : new()
{
    public bool HasError { get; set; } = false;

    public T Item { get; set; } = new T();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
