namespace MedicApp.SharedKernel;

public class PhoneNumber : ValueObject<PhoneNumber>
{
    public string CountryCode { get; set; } = string.Empty;

    public string Number { get; set; } = string.Empty;
}
