namespace ClinicManagement.ApplicationCore.Models.Responses;

public class DepartmentResponse : ResponseBase
{
    public BranchItem Branch { get; set; } = new();

    public string Name { get; set; } = string.Empty;

    public PhoneNumber PhoneNumber { get; set; } = new();
}
