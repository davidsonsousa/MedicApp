namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IService<T> where T : EntityBase
{
    Task<ReturnValue> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
