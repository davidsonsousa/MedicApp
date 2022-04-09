namespace ClinicManagement.ApplicationCore.Interfaces;

public interface IService<T> where T : EntityBase
{
    Task<ReturnValue> Delete(long id);

    Task<T> GetById(long id);
}
