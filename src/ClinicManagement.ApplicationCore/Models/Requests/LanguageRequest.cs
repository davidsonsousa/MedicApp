namespace ClinicManagement.ApplicationCore.Models.Requests;

public class LanguageRequest : RequestBase
{
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}
