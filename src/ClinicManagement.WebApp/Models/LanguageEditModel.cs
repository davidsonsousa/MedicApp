namespace ClinicManagement.WebApp.Models;

public class LanguageEditModel
{
    [Required]
    public Guid VanityId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;
}
