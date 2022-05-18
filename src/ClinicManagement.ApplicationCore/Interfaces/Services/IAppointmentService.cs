namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IAppointmentService : IService<Appointment>
{
    Task<IResult> GetAllAppointments(CancellationToken cancellationToken = default);

    Task<IResult> GetAppointmentById(Guid id, CancellationToken cancellationToken = default);
}
