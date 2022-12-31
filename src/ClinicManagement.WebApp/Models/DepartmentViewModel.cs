namespace ClinicManagement.WebApp.Models;

public class DepartmentViewModel
{
    public Guid VanityId { get; set; }

    public BranchViewModel Branch { get; set; } = new();

    public string Name { get; set; } = string.Empty;
}
