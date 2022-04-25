namespace ClinicManagement.Infrastructure.Data;

public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
{
    public LanguageRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }
}
