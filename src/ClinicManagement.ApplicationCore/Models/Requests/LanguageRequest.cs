namespace ClinicManagement.ApplicationCore.Models.Requests;

public class LanguageRequest : RequestBase
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Code { get; set; } = string.Empty;
}
