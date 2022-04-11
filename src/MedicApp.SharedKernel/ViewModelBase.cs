namespace MedicApp.SharedKernel;

public abstract class ViewModelBase
{
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
