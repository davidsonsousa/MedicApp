namespace ClinicManagement.Infrastructure.Data;

public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
{
    public DoctorRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task AddDepartmentsToDoctorAsync(Doctor? doctor, IEnumerable<Department>? departments, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(doctor, nameof(doctor));
        Guard.Against.Null(departments, nameof(departments));

        Logger.DebugMethodCall(nameof(AddDepartmentsToDoctorAsync));

        var departmentDoctorList = departments.Select(dept => new DepartmentDoctor
        {
            DepartmentId = dept.Id,
            DoctorId = doctor.Id
        });

        await DbContext.Set<DepartmentDoctor>().AddRangeAsync(departmentDoctorList, cancellationToken);
    }

    public async Task AddLanguagesToDoctorAsync(Doctor? doctor, IEnumerable<Language>? languages, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(doctor, nameof(doctor));
        Guard.Against.Null(languages, nameof(languages));

        Logger.DebugMethodCall(nameof(AddLanguagesToDoctorAsync));

        var languagePersonList = languages.Select(lang => new LanguagePerson
        {
            LanguageId = lang.Id,
            PersonId = doctor.Id
        });

        await DbContext.Set<LanguagePerson>().AddRangeAsync(languagePersonList, cancellationToken);
    }

    public async Task<Doctor?> GetDoctorWithDepartmentsAndLanguagesById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetDoctorWithDepartmentsAndLanguagesById), id);

        return await DbContext.Set<Doctor>()
                              .Include(d => d.Departments)
                              .Include(d => d.Languages)
                              .AsSplitQuery()
                              .SingleOrDefaultAsync(q => q.VanityId == id, cancellationToken);
    }

    public async Task RemoveDepartmentsFromDoctorAsync(Doctor? doctor, IEnumerable<Department>? departments, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(doctor, nameof(doctor));
        Guard.Against.Null(departments, nameof(departments));

        Logger.DebugMethodCall(nameof(RemoveDepartmentsFromDoctorAsync));

        var departmentDoctorList = await DbContext.Set<DepartmentDoctor>()
                                                  .Where(dd => dd.DoctorId == doctor.Id && departments.Select(d => d.Id).Contains(dd.DepartmentId))
                                                  .ToListAsync(cancellationToken);

        if (departmentDoctorList is not null)
        {
            DbContext.RemoveRange(departmentDoctorList);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task RemoveLanguagesFromDoctorAsync(Doctor? doctor, IEnumerable<Language>? languages, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(doctor, nameof(doctor));
        Guard.Against.Null(languages, nameof(languages));

        Logger.DebugMethodCall(nameof(RemoveLanguagesFromDoctorAsync));

        var languagePersonList = await DbContext.Set<LanguagePerson>()
                                                .Where(dd => dd.PersonId == doctor.Id && languages.Select(d => d.Id).Contains(dd.LanguageId))
                                                .ToListAsync(cancellationToken);

        if (languagePersonList is not null)
        {
            DbContext.RemoveRange(languagePersonList);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task UpdateDoctorDepartmentsAsync(Doctor? doctor, IEnumerable<Department>? departments, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(doctor, nameof(doctor));

        Logger.DebugMethodCall(nameof(UpdateDoctorDepartmentsAsync));

        await RemoveDepartmentsFromDoctorAsync(doctor, doctor.Departments, cancellationToken);
        await AddDepartmentsToDoctorAsync(doctor, departments, cancellationToken);
    }

    public async Task UpdateDoctorLanguagesAsync(Doctor? doctor, IEnumerable<Language>? languages, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(doctor, nameof(doctor));

        Logger.DebugMethodCall(nameof(UpdateDoctorLanguagesAsync));

        await RemoveLanguagesFromDoctorAsync(doctor, doctor.Languages, cancellationToken);
        await AddLanguagesToDoctorAsync(doctor, languages, cancellationToken);
    }
}
