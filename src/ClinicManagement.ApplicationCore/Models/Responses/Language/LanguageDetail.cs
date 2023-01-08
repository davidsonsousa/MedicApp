namespace ClinicManagement.ApplicationCore.Models.Responses.Language;

public class LanguageDetail
{
    public Guid VanityId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}
