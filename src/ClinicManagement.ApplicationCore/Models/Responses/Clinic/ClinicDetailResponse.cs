namespace ClinicManagement.ApplicationCore.Models.Responses.Clinic;

public class ClinicDetailResponse : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<BranchItem> Branches { get; set; } = new List<BranchItem>();
}
