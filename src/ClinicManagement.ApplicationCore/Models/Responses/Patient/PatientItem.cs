namespace ClinicManagement.ApplicationCore.Models.Responses.Patient;

public class PatientItem
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public IEnumerable<string> SelectedLanguages { get; set; } = new List<string>();
}
