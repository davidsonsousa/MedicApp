namespace ClinicManagement.ApplicationCore.Models.Responses.Employee;

public class EmployeeResponse : RequestBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public IEnumerable<Guid> LanguageIds { get; set; } = new List<Guid>();

    public IEnumerable<Guid> DepartmentIds { get; set; } = new List<Guid>();
}
