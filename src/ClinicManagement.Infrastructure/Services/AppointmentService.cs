namespace ClinicManagement.Infrastructure.Services;

public class AppointmentService : ServiceBase<Appointment>, IAppointmentService
{
    private readonly IAppointmentRepository appointmentRepository;
    private readonly IDoctorRepository doctorRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, ILoggerFactory loggerFactory)
        : base(appointmentRepository, loggerFactory)
    {
        this.appointmentRepository = appointmentRepository;
        this.doctorRepository = doctorRepository;
    }

    public async Task<IResult> GetAllAppointments(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllAppointments));
        var result = new Result<IEnumerable<AppointmentPatientResponse>>();

        try
        {
            var appointments = await appointmentRepository.GetAppointmentsWithPatientAsync(cancellationToken);
            Guard.Against.Null(appointments, nameof(appointments));

            result.Value = appointments.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(AppointmentService), nameof(GetAllAppointments));
            result.SetErrorMessage("An error has occurred while loading the appointments");
        }

        return result;
    }

    public async Task<IResult> GetAppointmentById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(AppointmentService), nameof(GetAppointmentById), id);
        var result = new Result<AppointmentPatientResponse>();

        try
        {
            var appointments = await Repository.GetByIdAsync(id, cancellationToken);
            Guard.Against.Null(appointments, nameof(appointments));

            result.Value = appointments.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(AppointmentService), nameof(GetAppointmentById));
            result.SetErrorMessage("An error has occurred while loading the appointments");
        }

        return result;
    }
}
