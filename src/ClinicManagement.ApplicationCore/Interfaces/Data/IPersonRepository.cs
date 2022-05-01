namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IPersonRepository<TEntity> where TEntity : Person
{
    Task AddLanguagesToPersonAsync(TEntity? person, IEnumerable<Language>? languages, CancellationToken cancellationToken = default);

    Task RemoveLanguagesFromPersonAsync(TEntity? person, IEnumerable<Language>? languages, CancellationToken cancellationToken = default);

    Task UpdatePersonLanguagesAsync(TEntity? person, IEnumerable<Language>? languages, CancellationToken cancellationToken = default);
}
