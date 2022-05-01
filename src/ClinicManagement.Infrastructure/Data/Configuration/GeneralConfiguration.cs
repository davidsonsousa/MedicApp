namespace ClinicManagement.Infrastructure.Data.Configuration;

public static class GeneralConfiguration
{
    public static void AddPropertiesForAuditing<T>(EntityTypeBuilder<T> builder) where T : EntityBase
    {
        builder.Property<DateTime>("DateCreated").HasDefaultValueSql("getdate()");
        builder.Property<DateTime>("DateModified").HasDefaultValueSql("getdate()");
        builder.Property<string>("UserCreated").HasMaxLength(50);
        builder.Property<string>("UserModified").HasMaxLength(50);
    }

    public static void AddVanityId<T>(EntityTypeBuilder<T> builder) where T : EntityBase
    {
        builder.Property(model => model.VanityId)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("newid()");

        builder.HasIndex(model => model.VanityId)
               .IsUnique();
    }

    public static IEnumerable<Clinic> SeedClinics()
    {
        return new List<Clinic>
        {
            new Clinic
            {
                Id = 1,
                Name = "Whatever Medical Center"
            },
            new Clinic
            {
                Id = 2,
                Name = "Random Clinic"
            }
        };
    }

    public static IEnumerable<Branch> SeedBranches()
    {
        return new List<Branch>
        {
            new Branch
            {
                Id = 1,
                ClinicId = 1,
                Name = "WMC - Prague 1"
            },
            new Branch
            {
                Id = 2,
                ClinicId = 1,
                Name = "WMC - Prague 3"
            },
            new Branch
            {
                Id = 3,
                ClinicId = 2,
                Name = "RC - Prague 5"
            },
            new Branch
            {
                Id = 4,
                ClinicId = 2,
                Name = "RC - Prague 9"
            }
        };
    }

    public static IEnumerable<dynamic> SeedBranchAddresses()
    {
        return new[]
        {
            new { BranchId = 1L, Street = "ul. Ulicova 1011/10", ZipCode="110 00", City = "Prague", Country = "CZ" },
            new { BranchId = 2L, Street = "ul. Ulicova 3033/30", ZipCode="330 00", City = "Prague", Country = "CZ" },
            new { BranchId = 3L, Street = "ul. Ulicova 5055/50", ZipCode="550 00", City = "Prague", Country = "CZ" },
            new { BranchId = 4L, Street = "ul. Ulicova 9000/90", ZipCode="990 00", City = "Prague", Country = "CZ" }
        };
    }

    public static IEnumerable<Department> SeedDepartments()
    {
        return new List<Department>
        {
            new Department
            {
                Id = 1,
                BranchId = 1,
                Name= "General practitioner"
            },
            new Department
            {
                Id = 2,
                BranchId = 1,
                Name= "Urology"
            },
            new Department
            {
                Id = 3,
                BranchId = 1,
                Name= "Paediatrics"
            },
            new Department
            {
                Id = 4,
                BranchId = 2,
                Name= "Internal medicine"
            },
            new Department
            {
                Id = 5,
                BranchId = 2,
                Name= "Cardiology"
            },
            new Department
            {
                Id = 6,
                BranchId = 2,
                Name= "Ophthalmology"
            }
        };
    }

    public static IEnumerable<Language> SeedLanguages()
    {
        return new List<Language>
        {
            new Language
            {
                Id= 1,
                Name = "Czech",
                Code = "CZ"
            },
            new Language
            {
                Id= 2,
                Name = "English",
                Code = "EN"
            },
            new Language
            {
                Id= 3,
                Name = "Polish",
                Code = "PL"
            },
            new Language
            {
                Id= 4,
                Name = "Russian",
                Code = "RU"
            },
        };
    }
}