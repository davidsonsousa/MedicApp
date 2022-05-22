﻿namespace ClinicManagement.Infrastructure.Data.Configuration;

public static class GeneralConfiguration
{
    public static void AddPropertiesForAuditing<T>(EntityTypeBuilder<T> builder) where T : EntityBase
    {
        builder.Property<DateTime>("DateCreated").HasDefaultValueSql("getdate()").HasColumnOrder(96);
        builder.Property<DateTime>("DateModified").HasDefaultValueSql("getdate()").HasColumnOrder(97);
        builder.Property<string>("UserCreated").HasMaxLength(50).HasColumnOrder(98);
        builder.Property<string>("UserModified").HasMaxLength(50).HasColumnOrder(99);
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

    public static IEnumerable<dynamic> SeedBranchPhoneNumbers()
    {
        return new[]
        {
            new { BranchId = 1L, CountryCode = "420", Number = "999888777" },
            new { BranchId = 2L, CountryCode = "420", Number = "666555444" },
            new { BranchId = 3L, CountryCode = "420", Number = "333222111" },
            new { BranchId = 4L, CountryCode = "420", Number = "999666333" }
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

    public static IEnumerable<dynamic> SeedDepartmentPhoneNumbers()
    {
        return new[]
        {
            new { DepartmentId = 1L, CountryCode = "420", Number = "999888777" },
            new { DepartmentId = 2L, CountryCode = "420", Number = "666555444" },
            new { DepartmentId = 3L, CountryCode = "420", Number = "333222111" },
            new { DepartmentId = 4L, CountryCode = "420", Number = "999666333" },
            new { DepartmentId = 5L, CountryCode = "420", Number = "888555222" },
            new { DepartmentId = 6L, CountryCode = "420", Number = "777444111" }
        };
    }

    public static IEnumerable<Language> SeedLanguages()
    {
        return new List<Language>
        {
            new Language { Id= 1, Name = "Czech", Code = "CZ" },
            new Language { Id= 2, Name = "English", Code = "EN" },
            new Language { Id= 3, Name = "Polish", Code = "PL" },
            new Language { Id= 4, Name = "Russian", Code = "RU" },
        };
    }

    public static IEnumerable<dynamic> SeedDoctors()
    {
        return new[]
        {
            new
            {
                Id = 1L,
                Name = "John",
                Surname ="Doe",
                DateOfBirth = new DateOnly(1970, 02, 10),
                IsDeleted = false
            },
            new
            {
                Id = 2L,
                Name = "Mary",
                Surname ="Sue",
                DateOfBirth = new DateOnly(1975, 05, 08),
                IsDeleted = false
            },
        };
    }

    public static IEnumerable<dynamic> SeedNurses()
    {
        return new[]
        {
            new
            {
                Id = 3L,
                Name = "Pavla",
                Surname ="Novakova",
                DateOfBirth = new DateOnly(1980, 04, 22),
                IsDeleted = false
            },
            new
            {
                Id = 4L,
                Name = "Lenka",
                Surname ="Novakova",
                DateOfBirth = new DateOnly(1985, 03, 15),
                IsDeleted = false
            },
        };
    }

    public static IEnumerable<dynamic> SeedPatients()
    {
        return new[]
        {
            new
            {
                Id = 5L,
                Name = "Bob",
                Surname ="Smith",
                DateOfBirth = new DateOnly(1981, 05, 23),
                IsDeleted = false
            },
            new
            {
                Id = 6L,
                Name = "Karen",
                Surname ="Horner",
                DateOfBirth = new DateOnly(1986, 04, 16),
                IsDeleted = false
            },
        };
    }

    public static IEnumerable<dynamic> SeedPersonAddresses()
    {
        return new[]
        {
            new { PersonId = 1L, Street = "ul. Doktorova 1010/10", ZipCode="110 00", City = "Prague", Country = "CZ" },
            new { PersonId = 2L, Street = "ul. Nemocinice 2020/20", ZipCode="220 00", City = "Prague", Country = "CZ" },
            new { PersonId = 3L, Street = "ul. Sersterska 3030/30", ZipCode="330 00", City = "Prague", Country = "CZ" },
            new { PersonId = 4L, Street = "ul. Sersterska 3031/31", ZipCode="330 00", City = "Prague", Country = "CZ" },
            new { PersonId = 5L, Street = "ul. Pacientu 4000/40", ZipCode="440 00", City = "Prague", Country = "CZ" },
            new { PersonId = 6L, Street = "ul. Pacientu 4444/44", ZipCode="440 00", City = "Prague", Country = "CZ" }
        };
    }

    public static IEnumerable<dynamic> SeedPersonPhoneNumbers()
    {
        return new[]
        {
            new { PersonId = 1L, CountryCode = "420", Number = "987654321" },
            new { PersonId = 2L, CountryCode = "420", Number = "789456123" },
            new { PersonId = 3L, CountryCode = "420", Number = "777888999" },
            new { PersonId = 4L, CountryCode = "420", Number = "888444333" },
            new { PersonId = 5L, CountryCode = "420", Number = "654321789" },
            new { PersonId = 6L, CountryCode = "420", Number = "321456987" }
        };
    }

    public static IEnumerable<LanguagePerson> SeedLanguagePeople()
    {
        return new List<LanguagePerson>
        {
            new LanguagePerson { LanguageId = 1, PersonId = 1 },
            new LanguagePerson { LanguageId = 2, PersonId = 1 },
            new LanguagePerson { LanguageId = 1, PersonId = 2 },
            new LanguagePerson { LanguageId = 2, PersonId = 2 },
            new LanguagePerson { LanguageId = 1, PersonId = 3 },
            new LanguagePerson { LanguageId = 4, PersonId = 3 },
            new LanguagePerson { LanguageId = 1, PersonId = 4 },
            new LanguagePerson { LanguageId = 3, PersonId = 4 },
            new LanguagePerson { LanguageId = 2, PersonId = 5 },
            new LanguagePerson { LanguageId = 2, PersonId = 6 }
        };
    }

    public static IEnumerable<DepartmentEmployee> SeedDepartmentEmployees()
    {
        return new List<DepartmentEmployee>
        {
            new DepartmentEmployee { DepartmentId = 1, EmployeeId = 1 },
            new DepartmentEmployee { DepartmentId = 2, EmployeeId = 2 },
            new DepartmentEmployee { DepartmentId = 1, EmployeeId = 3 },
            new DepartmentEmployee { DepartmentId = 2, EmployeeId = 4 }
        };
    }
}