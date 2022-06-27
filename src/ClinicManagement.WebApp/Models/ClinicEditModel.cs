namespace ClinicManagement.WebApp.Models;

public class ClinicEditModel
{
    [Required]
    public Guid VanityId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<BranchEditModel> Branches { get; set; } = new List<BranchEditModel>();
}
