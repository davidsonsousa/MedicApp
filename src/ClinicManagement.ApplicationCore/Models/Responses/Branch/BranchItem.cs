namespace ClinicManagement.ApplicationCore.Models.Responses.Branch;

public class BranchItem : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public PhoneNumber PhoneNumber { get; set; } = new();
}
