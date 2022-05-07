namespace MedicApp.SharedKernel;

public class Address : ValueObject<Address>
{
    [Required]
    public string Street { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    public string? State { get; set; }

    [Required]
    public string Country { get; set; } = string.Empty;

    [Required]
    public string ZipCode { get; set; } = string.Empty;
}
