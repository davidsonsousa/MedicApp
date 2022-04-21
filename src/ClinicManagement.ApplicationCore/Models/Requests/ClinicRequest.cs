namespace ClinicManagement.ApplicationCore.Models.Requests;

public class ClinicRequest : RequestBase
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Guid> SelectedBranches { get; set; } = new List<Guid>();

    public override string ToString()
    {
        var jsonResult = new JObject(
                                    new JProperty("VanityId", VanityId),
                                    new JProperty("Name", Name),
                                    new JProperty("SelectedBranches", string.Join(',', SelectedBranches))
                                );
        return jsonResult.ToString();
    }
}
