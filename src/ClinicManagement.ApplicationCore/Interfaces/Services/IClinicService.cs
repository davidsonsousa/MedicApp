namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IClinicService : IService<Clinic>
{
    Task<IResult> GetAllClinics(CancellationToken cancellationToken = default);

    Task<IResult> GetClinicById(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> SaveAsync(ClinicEditModel model, CancellationToken cancellationToken = default);
}
