namespace MedicApp.SharedKernel;

public class PhoneNumber : ValueObject<PhoneNumber>
{
    [Required]
    [Column(Order = 40)]
    public string CountryCode { get; set; } = string.Empty;

    [Required]
    [Column(Order = 41)]
    public string Number { get; set; } = string.Empty;
}
