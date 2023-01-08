namespace ClinicManagement.ApplicationCore.Models.Responses.Employee;

public class EmployeeDetail
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public IEnumerable<LanguageItem> Languages { get; set; } = new List<LanguageItem>();

    public IEnumerable<DepartmentItem> Departments { get; set; } = new List<DepartmentItem>();
}
