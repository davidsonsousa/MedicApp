namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IService<T> where T : EntityBase
{
    Task<ReturnValue> Delete(long id);
}
