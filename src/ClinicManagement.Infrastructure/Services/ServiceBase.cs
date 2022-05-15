namespace ClinicManagement.Infrastructure.Services;

public abstract class ServiceBase<T> : IService<T> where T : EntityBase
{
    protected readonly IRepository<T> Repository;
    protected readonly ILogger Logger;

    public ServiceBase(IRepository<T> repository, ILoggerFactory loggerFactory)
    {
        Repository = repository;
        Logger = loggerFactory.CreateLogger(nameof(ServiceBase<T>));
    }

    public async virtual Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await Repository.GetByIdAsync(id, cancellationToken);

        Guard.Against.Null(item, nameof(item));

        var result = new Result($"Item '{item.Id}' deleted at {DateTime.Now:T}.");

        try
        {
            Repository.Delete(item, cancellationToken);
            await Repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, Constants.DebugMessages.ClassMethod, nameof(ServiceBase<T>), nameof(DeleteAsync));
            result.SetErrorMessage("An error has occurred while deleting the item");
        }

        return result;
    }
}
