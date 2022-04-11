namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IClinicService
{
    Task<ReturnValue> SaveAsync(ClinicEditModel model);
}
