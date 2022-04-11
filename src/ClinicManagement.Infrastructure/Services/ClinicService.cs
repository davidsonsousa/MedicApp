namespace ClinicManagement.Infrastructure.Services;

public class ClinicService : ServiceBase<Clinic>, IClinicService
{
    public ClinicService(IRepository<Clinic> repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
    {

    }

    public async Task<ReturnValue> SaveAsync(ClinicEditModel model)
    {
        Logger.LogDebug($"{nameof(ClinicService)} > {nameof(SaveAsync)}: {model.ToString}");
        var returnValue = new ReturnValue($"Clinic '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model);
            await Repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            returnValue.SetErrorMessage("An error has occurred while saving the clinic");
        }

        return returnValue;
    }

    private async Task AddOrUpdateAsync(ClinicEditModel model)
    {
        if (model.IsNew)
        {
            var clinic = model.MapToEntity();
            await Repository.AddAsync(clinic);
        }
        else
        {
            var clinic = model.MapToEntity(await Repository.GetByIdAsync(model.VanityId));
            await Repository.UpdateAsync(clinic);
        }
    }
}
