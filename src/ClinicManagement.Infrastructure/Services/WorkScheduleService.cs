namespace ClinicManagement.Infrastructure.Services;

public class WorkScheduleService : ServiceBase<WorkSchedule>, IWorkScheduleService
{
    private readonly IWorkScheduleRepository workScheduleRepository;
    private readonly IDoctorRepository doctorRepository;
    private readonly IDepartmentRepository departmentRepository;

    public WorkScheduleService(IWorkScheduleRepository workScheduleRepository, IDoctorRepository doctorRepository,
                               IDepartmentRepository departmentRepository, ILoggerFactory loggerFactory)
        : base(workScheduleRepository, loggerFactory)
    {
        this.workScheduleRepository = workScheduleRepository;
        this.doctorRepository = doctorRepository;
        this.departmentRepository = departmentRepository;
    }

    public async Task<IResult> GetAllWorkSchedules(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllWorkSchedules));
        var result = new Result<IEnumerable<WorkScheduleEmployeeResponse>>();

        try
        {
            var workSchedules = await workScheduleRepository.GetWorkSchedulesWithEmployeeAndDepartmentAsync(cancellationToken);
            Guard.Against.Null(workSchedules, nameof(workSchedules));

            result.Value = workSchedules.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(WorkScheduleService), nameof(GetAllWorkSchedules));
            result.SetErrorMessage("An error has occurred while loading the workSchedules");
        }

        return result;
    }

    public async Task<IResult> GetWorkScheduleById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(WorkScheduleService), nameof(GetWorkScheduleById), id);
        var result = new Result<WorkScheduleEmployeeResponse>();

        try
        {
            var workSchedules = await Repository.GetByIdAsync(id, cancellationToken);
            Guard.Against.Null(workSchedules, nameof(workSchedules));

            result.Value = workSchedules.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(WorkScheduleService), nameof(GetWorkScheduleById));
            result.SetErrorMessage("An error has occurred while loading the workSchedules");
        }

        return result;
    }
}
