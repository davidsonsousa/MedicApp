namespace ClinicManagement.ApplicationCore.Models.Responses.Branch;

public class BranchWithClinicResponse : ResponseBase
{
    public ClinicItem Clinic { get; set; } = new();

    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public PhoneNumber PhoneNumber { get; set; } = new();

    public IEnumerable<Guid> DepartmentIds { get; set; } = new List<Guid>();
}
