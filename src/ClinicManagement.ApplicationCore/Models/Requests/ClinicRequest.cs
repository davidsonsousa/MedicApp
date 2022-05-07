namespace ClinicManagement.ApplicationCore.Models.Requests;

public class ClinicRequest : RequestBase
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Guid> SelectedBranches { get; set; } = new List<Guid>();
}
