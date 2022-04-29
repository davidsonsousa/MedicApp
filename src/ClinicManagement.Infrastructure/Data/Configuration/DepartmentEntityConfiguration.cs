namespace ClinicManagement.Infrastructure.Data.Configuration;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        // Relationships
        builder.HasMany(dept => dept.Doctors)
               .WithMany(doc => doc.Departments)
               .UsingEntity<DepartmentDoctor>(b => b.HasOne<Doctor>().WithMany(),
                                              b => b.HasOne<Department>().WithMany());

        builder.HasMany(dept => dept.Nurses)
               .WithMany(nur => nur.Departments)
               .UsingEntity<DepartmentNurse>(b => b.HasOne<Nurse>().WithMany(),
                                              b => b.HasOne<Department>().WithMany());

        builder.HasData(GeneralConfiguration.SeedDepartments());
    }
}
