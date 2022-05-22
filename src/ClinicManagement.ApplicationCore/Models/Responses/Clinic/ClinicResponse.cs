namespace ClinicManagement.ApplicationCore.Models.Responses.Clinic;

public class ClinicResponse : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Guid> SelectedBranches { get; set; } = new List<Guid>();
}
