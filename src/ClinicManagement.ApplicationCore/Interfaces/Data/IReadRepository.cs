﻿namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IReadRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Get entity by Id (primary key)
    /// </summary>
    /// <param name="id">Value of the Id</param>
    /// <returns></returns>
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get entity by VanityId
    /// </summary>
    /// <param name="vanityId">Value of the Vanity Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity?> GetByIdAsync(Guid vanityId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all records which were not marked as deleted (IsDeleted == false)
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets items based on condition for read-only
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetReadOnlyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the total number of records
    /// </summary>
    /// <returns></returns>
    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the total number of records based on condition
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
}
