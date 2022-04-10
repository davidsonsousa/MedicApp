namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IChangeRangeRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Inserts multiple records
    /// </summary>
    /// <param name="entities"></param>
    Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates multiple records
    /// </summary>
    /// <param name="entities"></param>
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes multiple records
    /// </summary>
    /// <param name="entities"></param>
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}
