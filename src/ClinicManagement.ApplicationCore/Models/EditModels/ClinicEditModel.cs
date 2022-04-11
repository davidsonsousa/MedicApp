namespace ClinicManagement.ApplicationCore.Models.EditModels;

public class ClinicEditModel : EditModelBase
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Guid> SelectedBranches { get; set; } = new List<Guid>();
}
