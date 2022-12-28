namespace ClinicManagement.ApplicationCore.Models.Requests;

public class DepartmentRequest : RequestBase
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public PhoneNumber PhoneNumber { get; set; } = new();

    public Guid BranchId { get; set; }
}
