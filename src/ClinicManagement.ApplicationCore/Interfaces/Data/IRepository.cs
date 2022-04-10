namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IChangeRepository<TEntity> where TEntity : EntityBase
{

}
