namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IChangeRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Adds a record
    /// </summary>
    /// <param name="entity"></param>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates record
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes record from database
    /// </summary>
    /// <param name="entity"></param>
    void Delete(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Persists changes to the database
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
