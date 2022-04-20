namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IClinicService : IService<Clinic>
{
    Task<IReturnValue> GetAllClinics(CancellationToken cancellationToken = default);

    Task<IReturnValue> GetClinicById(Guid id, CancellationToken cancellationToken = default);

    Task<IReturnValue> SaveAsync(ClinicEditModel model, CancellationToken cancellationToken = default);
}
