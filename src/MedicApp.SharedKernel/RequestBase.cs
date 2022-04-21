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
        var jsonResult = new JObject(
                                    new JProperty("VanityId", VanityId)
                                );
        return jsonResult.ToString();
    }

}
