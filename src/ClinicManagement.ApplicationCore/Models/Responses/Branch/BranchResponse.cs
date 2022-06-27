namespace ClinicManagement.ApplicationCore.Models.Responses.Branch;

public class BranchResponse : ResponseBase
{
    public Guid ClinicId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new Address();

    public IEnumerable<Guid> DepartmentIds { get; set; } = new List<Guid>();
}
