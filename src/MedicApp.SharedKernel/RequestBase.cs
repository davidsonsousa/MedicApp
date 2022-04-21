namespace MedicApp.SharedKernel;

public abstract class RequestBase
{
    public bool IsNew {
        get {
            return VanityId == Guid.Empty;
        }
    }

    public Guid VanityId { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

}
