namespace ClinicManagement.WebApp.Models;

public class DepartmentEditModel
{
    [Required]
    public Guid VanityId { get; set; }

    [Required]
    public Guid BranchId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public PhoneNumber PhoneNumber { get; set; } = new();
}
