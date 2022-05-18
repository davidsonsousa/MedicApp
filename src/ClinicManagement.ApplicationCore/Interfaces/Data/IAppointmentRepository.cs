namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<IEnumerable<Appointment>> GetAppointmentsWithPatientAsync(CancellationToken cancellationToken);
}
