namespace ClinicManagement.ApplicationCore.Models.ViewModels;

public class ClinicViewModel : ViewModelBase
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Guid> SelectedBranches { get; set; } = new List<Guid>();
}
