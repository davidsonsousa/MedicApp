namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IWorkScheduleService : IService<WorkSchedule>
{
    Task<IResult> GetAllWorkSchedules(CancellationToken cancellationToken = default);

    Task<IResult> GetWorkScheduleById(Guid id, CancellationToken cancellationToken = default);
}
