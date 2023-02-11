namespace ClinicManagement.ApplicationCore.Models.Responses.Clinic;

public class ClinicDetail
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<BranchDetail> Branches { get; set; } = new List<BranchDetail>();
}
