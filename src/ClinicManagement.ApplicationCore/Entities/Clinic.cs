namespace ClinicManagement.ApplicationCore.Entities;

public class Clinic : EntityBase
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public override string ToString()
    {
        var jsonResult = new JObject(
                                    new JProperty("Id", Id),
                                    new JProperty("VanityId", VanityId),
                                    new JProperty("Name", Name),
                                    new JProperty("Branches", string.Join(',', Branches))
                                );
        return jsonResult.ToString();
    }
}
