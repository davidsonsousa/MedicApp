namespace ClinicManagement.Infrastructure.Services;

public class ClinicService : ServiceBase<Clinic>, IClinicService
{
    public ClinicService(IRepository<Clinic> repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
    {

    }

    public async Task<IReturnValue> GetClinicById(Guid id)
    {
        Logger.LogDebug(Constants.DebugMessages.ClassMethodObjectValue, nameof(ClinicService), nameof(GetClinicById), nameof(id), id);
        var returnValue = new ReturnValue<ClinicViewModel>();

        try
        {
            var clinic = await Repository.GetByIdAsync(id);
            Guard.Against.Null(clinic, nameof(clinic));

            returnValue.Value = clinic.MapToViewModel();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, Constants.DebugMessages.ClassMethod, nameof(ClinicService), nameof(GetClinicById));
            returnValue.SetErrorMessage("An error has occurred while loading the clinic");
        }

        return returnValue;
    }

    public async Task<IReturnValue> SaveAsync(ClinicEditModel model)
    {
        Logger.LogDebug(Constants.DebugMessages.ClassMethodObjectValue, nameof(ClinicService), nameof(SaveAsync), nameof(model), model);
        var returnValue = new ReturnValue($"Clinic '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model);
            await Repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, Constants.DebugMessages.ClassMethod, nameof(ClinicService), nameof(SaveAsync));
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
