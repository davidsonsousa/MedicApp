namespace ClinicManagement.ApplicationCore.Models.Responses.Branch;

public class BranchDetail
{
    public Guid VanityId { get; set; }

    public Guid ClinicId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public PhoneNumber PhoneNumber { get; set; } = new();
}
