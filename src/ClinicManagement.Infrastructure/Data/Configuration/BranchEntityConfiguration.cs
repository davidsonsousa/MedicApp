namespace ClinicManagement.Infrastructure.Data.Configuration
{
    public class BranchEntityConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            GeneralConfiguration.AddPropertiesForAuditing(builder);
            GeneralConfiguration.AddVanityId(builder);
        }
    }
}
