namespace ClinicManagement.ApplicationCore.Models.Requests;

public class DoctorRequest : RequestBase
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Surname { get; set; } = string.Empty;

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    public Address Address { get; set; } = new Address();

    [Required]
    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public IEnumerable<Guid> SelectedLanguages { get; set; } = new List<Guid>();

    public IEnumerable<Guid> SelectedDepartments { get; set; } = new List<Guid>();
}
