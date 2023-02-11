namespace MedicApp.SharedKernel;

public abstract class ListResponseBase<T> where T : class
{
    public bool HasError { get; set; }

    public int Count => Items.Count();

    public IEnumerable<T> Items { get; set; } = new List<T>();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
