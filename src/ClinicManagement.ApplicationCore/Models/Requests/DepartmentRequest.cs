namespace ClinicManagement.ApplicationCore.Models.Requests;

public class DepartmentRequest : RequestBase
{
    public string Name { get; set; } = string.Empty;

    public Guid BranchId { get; set; }
}
