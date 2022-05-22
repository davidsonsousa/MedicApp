namespace MedicApp.SharedKernel;

public abstract class ResponseBase
{
    public Guid VanityId { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
