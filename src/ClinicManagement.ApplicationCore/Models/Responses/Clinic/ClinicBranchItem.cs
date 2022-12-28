namespace ClinicManagement.ApplicationCore.Models.Responses.Clinic;

public class ClinicBranchItem : ResponseBase
{
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public PhoneNumber PhoneNumber { get; set; } = new();
}
