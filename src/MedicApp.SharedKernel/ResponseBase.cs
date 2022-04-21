namespace MedicApp.SharedKernel;

public abstract class ResponseBase
{
    public Guid VanityId { get; set; }

    public override string ToString()
    {
        var jsonResult = new JObject(
                                    new JProperty("VanityId", VanityId)
                                );
        return jsonResult.ToString();
    }

}
