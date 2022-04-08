namespace MedicApp.SharedKernel
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string? State { get; set; }

        public string Country { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;
    }
}
