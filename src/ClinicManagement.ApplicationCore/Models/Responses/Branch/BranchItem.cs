namespace ClinicManagement.ApplicationCore.Models.Responses.Branch;

public class BranchItem
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int DepartmentCount { get; set; }
}
