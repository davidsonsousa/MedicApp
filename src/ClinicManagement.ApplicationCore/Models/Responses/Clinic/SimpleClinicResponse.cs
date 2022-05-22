namespace ClinicManagement.ApplicationCore.Models.Responses.Clinic;

public class SimpleClinicResponse : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Guid> BranchIds { get; set; } = new List<Guid>();
}
