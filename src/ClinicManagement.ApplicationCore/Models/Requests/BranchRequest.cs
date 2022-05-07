namespace ClinicManagement.ApplicationCore.Models.Requests;

public class BranchRequest : RequestBase
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Address Address { get; set; } = new Address();

    [Required]
    public Guid ClinicId { get; set; }

    public IEnumerable<Guid> SelectedDepartments { get; set; } = new List<Guid>();
}
