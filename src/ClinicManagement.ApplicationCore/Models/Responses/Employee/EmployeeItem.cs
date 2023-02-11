namespace ClinicManagement.ApplicationCore.Models.Responses.Employee;

public class EmployeeItem
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }
}
