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

    public async virtual Task<ReturnValue> Delete(long id)
    {
        var item = await Repository.GetByIdAsync(id);

        Guard.Against.Null(item, nameof(item));

        var returnValue = new ReturnValue($"Item '{item.Id}' deleted at {DateTime.Now:T}.");

        try
        {
            await Repository.DeleteAsync(item);
            await Repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, Constants.DebugMessages.ClassMethod, nameof(ServiceBase<T>), nameof(Delete));
            returnValue.SetErrorMessage("An error has occurred while deleting the item");
        }

        return returnValue;
    }
}
