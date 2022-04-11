namespace MedicApp.SharedKernel;

public abstract class EditModelBase
{
    public bool IsNew {
        get {
            return Id == 0 && VanityId == Guid.Empty;
        }
    }

    public long Id { get; set; }

    public Guid VanityId { get; set; }

    public override string ToString()
    {
        var jsonResult = new JObject(
                                    new JProperty("Id", Id),
                                    new JProperty("VanityId", VanityId)
                                );
        return jsonResult.ToString();
    }

}
