namespace ClinicManagement.ApplicationCore.Models.Responses.Patient;

public class PatientDetail
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public IEnumerable<string> SelectedLanguages { get; set; } = new List<string>();
}