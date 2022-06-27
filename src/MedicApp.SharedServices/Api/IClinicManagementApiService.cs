namespace MedicApp.SharedServices.Api;

public interface IClinicManagementApiService
{
    Task<bool> DeleteClinicAsync(Guid id);

    Task<T> GetClinicByIdAsync<T>(Guid id);

    Task<IEnumerable<T>> GetClinicsAsync<T>();

    Task<bool> InsertClinicAsync<T>(T model);

    Task<bool> UpdateClinicAsync<T>(T model);

    Task<bool> DeleteBranchAsync(Guid id);

    Task<T> GetBranchByIdAsync<T>(Guid id);

    Task<IEnumerable<T>> GetBranchesAsync<T>();

    Task<IEnumerable<T>> GetBranchesByClinicIdAsync<T>(Guid clinicId);

    Task<bool> InsertBranchAsync<T>(T model);

    Task<bool> UpdateBranchAsync<T>(T model);

    Task<bool> DeleteDepartmentAsync(Guid id);

    Task<T> GetDepartmentByIdAsync<T>(Guid id);

    Task<IEnumerable<T>> GetDepartmentsAsync<T>();

    Task<bool> InsertDepartmentAsync<T>(T model);

    Task<bool> UpdateDepartmentAsync<T>(T model);
}
