namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IClinicService
{
    Task<IReturnValue> GetClinicById(Guid id, CancellationToken cancellationToken = default);

    Task<IReturnValue> SaveAsync(ClinicEditModel model, CancellationToken cancellationToken = default);
}
