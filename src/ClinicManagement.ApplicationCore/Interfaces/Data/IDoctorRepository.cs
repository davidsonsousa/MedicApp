namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IDoctorRepository : IRepository<Doctor>
{
    Task AddDepartmentsToDoctorAsync(Doctor? doctor, IEnumerable<Department>? departments, CancellationToken cancellationToken = default);

    Task AddLanguagesToDoctorAsync(Doctor? doctor, IEnumerable<Language>? languages, CancellationToken cancellationToken = default);

    Task<Doctor?> GetDoctorWithDepartmentsAndLanguagesById(Guid id, CancellationToken cancellationToken = default);

    Task RemoveDepartmentsFromDoctorAsync(Doctor? doctor, IEnumerable<Department>? departments, CancellationToken cancellationToken = default);

    Task RemoveLanguagesFromDoctorAsync(Doctor? doctor, IEnumerable<Language>? languages, CancellationToken cancellationToken = default);

    Task UpdateDoctorDepartmentsAsync(Doctor? doctor, IEnumerable<Department>? departments, CancellationToken cancellationToken = default);

    Task UpdateDoctorLanguagesAsync(Doctor? doctor, IEnumerable<Language>? languages, CancellationToken cancellationToken = default);
}
