namespace ClinicManagement.WebApp.Models;

public class BranchViewModel
{
    public ClinicViewModel Clinic { get; set; } = new();

    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<Guid> DepartmentIds { get; set; } = new List<Guid>();
}
