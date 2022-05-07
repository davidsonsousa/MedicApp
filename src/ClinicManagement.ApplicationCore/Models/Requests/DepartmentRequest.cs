namespace ClinicManagement.ApplicationCore.Models.Requests;

public class DepartmentRequest : RequestBase
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public Guid BranchId { get; set; }
}
