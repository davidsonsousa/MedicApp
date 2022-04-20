namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IService<T> where T : EntityBase
{
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
