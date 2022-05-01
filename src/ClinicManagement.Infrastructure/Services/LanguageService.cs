namespace ClinicManagement.Infrastructure.Services;

public class LanguageService : ServiceBase<Language>, ILanguageService
{
    public LanguageService(ILanguageRepository languageRepository, ILoggerFactory loggerFactory)
        : base(languageRepository, loggerFactory)
    {

    }

    public async Task<IResult> GetAllLanguages(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllLanguages));
        var result = new Result<IEnumerable<LanguageResponse>>();

        try
        {
            var languages = await Repository.GetAllAsync(cancellationToken);
            Guard.Against.Null(languages, nameof(languages));

            result.Value = languages.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(LanguageService), nameof(GetAllLanguages));
            result.SetErrorMessage("An error has occurred while loading the languages");
        }

        return result;
    }


    public async Task<IResult> GetLanguageById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(LanguageService), nameof(GetLanguageById), id);
        var result = new Result<LanguageResponse>();

        try
        {
            var language = await Repository.GetByIdAsync(id, cancellationToken);
            Guard.Against.Null(language, nameof(language));

            result.Value = language.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(LanguageService), nameof(GetLanguageById));
            result.SetErrorMessage("An error has occurred while loading the language");
        }

        return result;
    }

    public async Task<IResult> SaveAsync(LanguageRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(LanguageService), nameof(SaveAsync), model);
        var result = new Result($"Language '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await Repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(LanguageService), nameof(GetLanguageById));
            result.SetErrorMessage("An error has occurred while saving the language");
        }

        return result;
    }

    private async Task AddOrUpdateAsync(LanguageRequest model, CancellationToken cancellationToken = default)
    {
        if (model.IsNew)
        {
            var language = model.MapToEntity();
            await Repository.AddAsync(language, cancellationToken);
        }
        else
        {
            var language = model.MapToEntity(await Repository.GetByIdAsync(model.VanityId, cancellationToken));
            Repository.Update(language, cancellationToken);
        }
    }
}
