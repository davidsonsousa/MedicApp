namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IDoctorService : IService<Doctor>
{
    Task<IResult> GetAllDoctors(CancellationToken cancellationToken = default);

    Task<IResult> GetAllDoctorWorkSchedules(CancellationToken cancellationToken = default);

    Task<IResult> GetDoctorById(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> SaveAsync(DoctorRequest model, CancellationToken cancellationToken = default);

    Task<IResult> SaveDoctorWorkScheduleAsync(WorkScheduleEmployeeRequest model, CancellationToken cancellationToken = default);
}
