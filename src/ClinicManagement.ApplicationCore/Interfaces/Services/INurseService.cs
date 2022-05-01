namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface INurseService : IService<Nurse>
{
    Task<IResult> GetAllNurses(CancellationToken cancellationToken = default);

    Task<IResult> GetNurseById(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> SaveAsync(NurseRequest model, CancellationToken cancellationToken = default);
}
