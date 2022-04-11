namespace ClinicManagement.Infrastructure.Data;

public abstract class RepositoryBase<TEntity> : IReadRepository<TEntity>, IChangeRepository<TEntity> where TEntity : EntityBase
{
    protected readonly ClinicManagementContext DbContext;
    protected readonly ILogger Logger;

    public RepositoryBase(ClinicManagementContext dbContext, LoggerFactory loggerFactory)
    {
        Guard.Against.Null(dbContext, nameof(dbContext));
        DbContext = dbContext;
        Logger = loggerFactory.CreateLogger("RepositoryBase");
    }

    public async virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity, nameof(entity));

        Logger.LogDebug(Constants.DebugMessages.MethodObjectValue, nameof(AddAsync), nameof(entity), entity);

        DbContext.Set<TEntity>().Add(entity);
        await SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async virtual Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        Logger.LogDebug(Constants.DebugMessages.Method, nameof(CountAsync));

        return await DbContext.Set<TEntity>().CountAsync(cancellationToken);
    }

    public async virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(filter, nameof(filter));

        Logger.LogDebug(Constants.DebugMessages.MethodObjectValue, nameof(CountAsync), nameof(filter), filter);

        return await DbContext.Set<TEntity>().CountAsync(filter, cancellationToken);
    }

    public async virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity, nameof(entity));

        Logger.LogDebug(Constants.DebugMessages.MethodObjectValue, nameof(DeleteAsync), nameof(entity), entity);

        // We never delete anything, only update the IsDelete flag
        entity.IsDeleted = true;
        await UpdateAsync(entity, cancellationToken);
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        Logger.LogDebug(Constants.DebugMessages.Method, nameof(GetAllAsync));

        return await GetValidRecords().ToListAsync(cancellationToken);
    }

    public async virtual Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        Logger.LogDebug(Constants.DebugMessages.Method, nameof(GetByIdAsync));

        return await DbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async virtual Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.LogDebug(Constants.DebugMessages.Method, nameof(GetByIdAsync));

        return await DbContext.Set<TEntity>().Where(q => q.VanityId == id).SingleOrDefaultAsync(cancellationToken);
    }

    public async virtual Task<IEnumerable<TEntity>> GetReadOnlyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        Logger.LogDebug(Constants.DebugMessages.MethodObjectValue, nameof(GetReadOnlyAsync), nameof(filter), filter);

        var records = GetValidRecords();

        if (filter != null)
        {
            records = records.Where(filter);
        }

        return await records.ToListAsync(cancellationToken);
    }

    public async virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        Logger.LogDebug(Constants.DebugMessages.Method, nameof(SaveChangesAsync));

        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity, nameof(entity));

        Logger.LogDebug(Constants.DebugMessages.MethodObjectValue, nameof(UpdateAsync), nameof(entity), entity);

        DbContext.Update(entity);
        await SaveChangesAsync(cancellationToken);
    }

    private IQueryable<TEntity> GetValidRecords()
    {
        Logger.LogDebug(Constants.DebugMessages.Method, nameof(GetValidRecords));

        return DbContext.Set<TEntity>().Where(q => q.IsDeleted == false);
    }
}
