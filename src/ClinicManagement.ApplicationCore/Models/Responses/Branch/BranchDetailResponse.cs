namespace ClinicManagement.ApplicationCore.Models.Responses.Branch;

public class BranchDetailResponse : ResponseBase
{
    public Guid ClinicId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new Address();

    public IEnumerable<DepartmentResponse> Departments { get; set; } = new List<DepartmentResponse>();
}
