namespace ClinicManagement.Infrastructure.Services;

public class ClinicService : ServiceBase<Clinic>, IClinicService
{
    public ClinicService(IClinicRepository clinicRepository, ILoggerFactory loggerFactory) : base(clinicRepository, loggerFactory)
    {

    }

    public async Task<IReturnValue> GetClinicById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(ClinicService), nameof(GetClinicById), id);
        var returnValue = new ReturnValue<ClinicViewModel>();

        try
        {
            var clinic = await Repository.GetByIdAsync(id, cancellationToken);
            Guard.Against.Null(clinic, nameof(clinic));

            returnValue.Value = clinic.MapToViewModel();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(ClinicService), nameof(GetClinicById));
            returnValue.SetErrorMessage("An error has occurred while loading the clinic");
        }

        return returnValue;
    }

    public async Task<IReturnValue> SaveAsync(ClinicEditModel model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(ClinicService), nameof(SaveAsync), model);
        var returnValue = new ReturnValue($"Clinic '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await Repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(ClinicService), nameof(GetClinicById));
            returnValue.SetErrorMessage("An error has occurred while saving the clinic");
        }

        return returnValue;
    }

    private async Task AddOrUpdateAsync(ClinicEditModel model, CancellationToken cancellationToken = default)
    {
        if (model.IsNew)
        {
            var clinic = model.MapToEntity();
            await Repository.AddAsync(clinic, cancellationToken);
        }
        else
        {
            var clinic = model.MapToEntity(await Repository.GetByIdAsync(model.VanityId, cancellationToken));
            await Repository.UpdateAsync(clinic, cancellationToken);
        }
    }
}
