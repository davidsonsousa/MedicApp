namespace ClinicManagement.ApplicationCore.Models.Responses.Clinic;

public class ClinicItem
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int BranchCount { get; set; }
}
