namespace ClinicManagement.Infrastructure.Data.Configuration;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        // Relationships
        builder.HasMany(dept => dept.Employees)
               .WithMany(doc => doc.Departments)
               .UsingEntity<DepartmentEmployee>(b => b.HasOne<Employee>().WithMany(),
                                                b => b.HasOne<Department>().WithMany());

        builder.HasData(GeneralConfiguration.SeedDepartments());
    }
}
