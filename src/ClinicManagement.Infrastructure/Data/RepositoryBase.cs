namespace ClinicManagement.Infrastructure.Data;

public abstract class RepositoryBase<TEntity> : IReadRepository<TEntity>, IChangeRepository<TEntity> where TEntity : Entity
{
    protected readonly ClinicManagementContext dbContext;

    public RepositoryBase(ClinicManagementContext dbContext)
    {
        Guard.Against.Null(dbContext);
        this.dbContext = dbContext;
    }

    public async virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity, nameof(entity));

        dbContext.Set<TEntity>().Add(entity);
        await SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async virtual Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().CountAsync(cancellationToken);
    }

    public async virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(filter, nameof(filter));

        return await dbContext.Set<TEntity>().CountAsync(filter, cancellationToken);
    }

    public async virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity, nameof(entity));

        // We never delete anything, only update the IsDelete flag
        entity.IsDeleted = true;
        await UpdateAsync(entity, cancellationToken);
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await GetValidRecords().ToListAsync(cancellationToken);
    }

    public async virtual Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async virtual Task<TEntity?> GetByVanityIdAsync(Guid vanityId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().Where(q => q.VanityId == vanityId).SingleOrDefaultAsync(cancellationToken);
    }

    public async virtual Task<IEnumerable<TEntity>> GetReadOnlyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var records = GetValidRecords();

        if (filter != null)
        {
            records = records.Where(filter);
        }

        return await records.ToListAsync(cancellationToken);
    }

    public async virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity, nameof(entity));

        dbContext.Update(entity);
        await SaveChangesAsync(cancellationToken);
    }

    private IQueryable<TEntity> GetValidRecords()
    {
        return dbContext.Set<TEntity>().Where(q => q.IsDeleted == false);
    }
}
