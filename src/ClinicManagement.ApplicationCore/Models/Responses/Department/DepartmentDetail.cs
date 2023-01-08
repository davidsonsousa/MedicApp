namespace ClinicManagement.ApplicationCore.Models.Responses.Department;

public class DepartmentDetail
{
    public Guid VanityId { get; set; }

    public Guid BranchId { get; set; }

    public string Name { get; set; } = string.Empty;

    public PhoneNumber PhoneNumber { get; set; } = new();
}