namespace ClinicManagement.WebApp.Models;

public class BranchEditModel
{
    [Required]
    public Guid VanityId { get; set; }

    [Required]
    public Guid ClinicId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public PhoneNumber PhoneNumber { get; set; } = new();

    public IEnumerable<DepartmentEditModel> Departments { get; set; } = new List<DepartmentEditModel>();
}
