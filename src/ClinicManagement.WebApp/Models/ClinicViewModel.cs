namespace ClinicManagement.WebApp.Models;

public class ClinicViewModel
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int BranchCount { get; set; }
}
