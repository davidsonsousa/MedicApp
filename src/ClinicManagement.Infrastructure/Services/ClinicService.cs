namespace ClinicManagement.Infrastructure.Services;

public class ClinicService : ServiceBase<Clinic>, IClinicService
{
    public ClinicService(IClinicRepository clinicRepository, ILoggerFactory loggerFactory) : base(clinicRepository, loggerFactory)
    {

    }

    public async Task<IResult> GetAllClinics(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllClinics));
        var result = new Result<IEnumerable<ClinicResponse>>();

        try
        {
            var clinics = await Repository.GetAllAsync(cancellationToken);
            Guard.Against.Null(clinics, nameof(clinics));

            result.Value = clinics.MapToViewModel();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(ClinicService), nameof(GetAllClinics));
            result.SetErrorMessage("An error has occurred while loading the clinics");
        }

        return result;
    }


    public async Task<IResult> GetClinicById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(ClinicService), nameof(GetClinicById), id);
        var result = new Result<ClinicResponse>();

        try
        {
            var clinic = await Repository.GetByIdAsync(id, cancellationToken);
            Guard.Against.Null(clinic, nameof(clinic));

            result.Value = clinic.MapToViewModel();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(ClinicService), nameof(GetClinicById));
            result.SetErrorMessage("An error has occurred while loading the clinic");
        }

        return result;
    }

    public async Task<IResult> SaveAsync(ClinicRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(ClinicService), nameof(SaveAsync), model);
        var result = new Result($"Clinic '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await Repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(ClinicService), nameof(GetClinicById));
            result.SetErrorMessage("An error has occurred while saving the clinic");
        }

        return result;
    }

    private async Task AddOrUpdateAsync(ClinicRequest model, CancellationToken cancellationToken = default)
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
