namespace MedicApp.SharedKernel;

public class PhoneNumber : ValueObject<PhoneNumber>
{
    [Required]
    public string CountryCode { get; set; } = string.Empty;

    [Required]
    public string Number { get; set; } = string.Empty;
}
