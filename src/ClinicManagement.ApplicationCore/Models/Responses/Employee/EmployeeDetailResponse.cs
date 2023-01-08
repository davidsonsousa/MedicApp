using ClinicManagement.ApplicationCore.Models.Responses.Department;
using ClinicManagement.ApplicationCore.Models.Responses.Language;

namespace ClinicManagement.ApplicationCore.Models.Responses.Employee;
public class EmployeeDetailResponse : RequestBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public IEnumerable<LanguageResponse> Languages { get; set; } = new List<LanguageResponse>();

    public IEnumerable<DepartmentResponse> Departments { get; set; } = new List<DepartmentResponse>();
}
