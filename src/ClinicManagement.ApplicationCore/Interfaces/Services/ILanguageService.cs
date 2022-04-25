namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface ILanguageService : IService<Language>
{
    Task<IResult> GetAllLanguages(CancellationToken cancellationToken = default);

    Task<IResult> GetLanguageById(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> SaveAsync(LanguageRequest model, CancellationToken cancellationToken = default);
}
