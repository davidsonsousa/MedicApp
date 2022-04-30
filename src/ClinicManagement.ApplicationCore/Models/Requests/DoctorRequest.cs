namespace ClinicManagement.ApplicationCore.Models.Requests;

public class DoctorRequest : RequestBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public IEnumerable<Guid> SelectedLanguages { get; set; } = new List<Guid>();

    public IEnumerable<Guid> SelectedDepartments { get; set; } = new List<Guid>();
}
