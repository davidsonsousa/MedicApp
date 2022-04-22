namespace ClinicManagement.ApplicationCore.Models.Responses;

public class DepartmentResponse : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public Guid BranchId { get; set; }
}
