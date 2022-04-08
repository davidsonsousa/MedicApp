namespace ClinicManagement.Infrastructure.Data.Configuration;

public static class GeneralConfiguration
{
    public static void AddPropertiesForAuditing<T>(EntityTypeBuilder<T> builder) where T : Entity
    {
        builder.Property<DateTime>("DateCreated");
        builder.Property<DateTime>("DateModified");
        builder.Property<string>("UserCreated").HasMaxLength(50);
        builder.Property<string>("UserModified").HasMaxLength(50);
    }

    public static void AddVanityId<T>(EntityTypeBuilder<T> builder) where T : Entity
    {
        builder.Property(model => model.VanityId)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("newid()");
    }
}
