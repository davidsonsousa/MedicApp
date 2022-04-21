namespace ClinicManagement.ApplicationCore.Models.Responses;

public class BranchResponse : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new Address();

    public Guid ClinicId { get; set; }

    public IEnumerable<Guid> SelectedDepartments { get; set; } = new List<Guid>();
}
