namespace ClinicManagement.ApplicationCore.Models.Responses.Branch;

public class BranchDetailResponse : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new Address();

    public IEnumerable<BranchDepartmentItem> Departments { get; set; } = new List<BranchDepartmentItem>();
}
