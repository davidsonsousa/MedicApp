namespace ClinicManagement.Infrastructure.Services;

public abstract class ServiceBase<T> : IService<T> where T : EntityBase
{
    private readonly IRepository<T> _repository;
    protected readonly ILogger logger;

    public ServiceBase(IRepository<T> repository, ILoggerFactory loggerFactory)
    {
        _repository = repository;
        logger = loggerFactory.CreateLogger(nameof(ServiceBase<T>));
    }

    public async Task<ReturnValue> Delete(long id)
    {
        var item = await _repository.GetByIdAsync(id);

        Guard.Against.Null(item);

        var returnValue = new ReturnValue($"Item '{item.Id}' deleted at {DateTime.Now:T}.");

        try
        {
            await _repository.DeleteAsync(item);
            await _repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            returnValue.SetErrorMessage("An error has occurred while deleting the item");
        }

        return returnValue;
    }

    public async Task<T> GetById(long id)
    {
        var item = await _repository.GetByIdAsync(id);

        Guard.Against.Null(item);

        // TODO: Map to DTO
        return item;
    }
}
