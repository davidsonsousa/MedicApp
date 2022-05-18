namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IPatientService : IService<Patient>
{
    Task<IResult> GetAllPatients(CancellationToken cancellationToken = default);

    Task<IResult> GetAllPatientAppointments(CancellationToken cancellationToken = default);

    Task<IResult> GetPatientById(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> SaveAsync(PatientRequest model, CancellationToken cancellationToken = default);

    Task<IResult> SavePatientAppointmentAsync(AppointmentPatientRequest model, CancellationToken cancellationToken = default);
}
