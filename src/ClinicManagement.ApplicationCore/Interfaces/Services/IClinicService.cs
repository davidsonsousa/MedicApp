namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IClinicService
{
    Task<IReturnValue> GetClinicById(Guid id);

    Task<IReturnValue> SaveAsync(ClinicEditModel model);
}
