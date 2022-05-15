namespace MedicApp.SharedKernel;

public class Address : ValueObject<Address>
{
    [Required]
    [Column(Order = 30)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [Column(Order = 31)]
    public string City { get; set; } = string.Empty;

    [Column(Order = 32)]
    public string? State { get; set; }

    [Required]
    [Column(Order = 33)]
    public string Country { get; set; } = string.Empty;

    [Required]
    [Column(Order = 34)]
    public string ZipCode { get; set; } = string.Empty;
}
