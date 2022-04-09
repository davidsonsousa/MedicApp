namespace ClinicManagement.ApplicationCore.Interfaces;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IChangeRepository<TEntity> where TEntity : EntityBase
{

}
