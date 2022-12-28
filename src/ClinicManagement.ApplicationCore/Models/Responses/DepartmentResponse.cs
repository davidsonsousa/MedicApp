namespace ClinicManagement.ApplicationCore.Models.Responses;

public class DepartmentResponse : ResponseBase
{
    public Guid BranchId { get; set; }

    public string Name { get; set; } = string.Empty;

    public PhoneNumber PhoneNumber { get; set; } = new();
}
