namespace ClinicManagement.ApplicationCore.Models.Requests;

public class DoctorResponse : RequestBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public IEnumerable<string> SelectedLanguages { get; set; } = new List<string>();

    public IEnumerable<Guid> SelectedDepartments { get; set; } = new List<Guid>();
}
