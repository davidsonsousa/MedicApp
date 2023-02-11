namespace MedicApp.SharedServices.Api;

public interface IClinicManagementApiService
{
    Task<ApiResponseModel> DeleteClinicAsync(Guid id);

    Task<ApiResponseItemModel<T>> GetClinicByIdAsync<T>(Guid id);

    Task<ApiResponseListModel<T>> GetClinicsAsync<T>();

    Task<ApiResponseModel> InsertClinicAsync<T>(T model);

    Task<ApiResponseModel> UpdateClinicAsync<T>(T model);

    Task<ApiResponseModel> DeleteBranchAsync(Guid id);

    Task<ApiResponseItemModel<T>> GetBranchByIdAsync<T>(Guid id);

    Task<ApiResponseListModel<T>> GetBranchesAsync<T>();

    Task<ApiResponseListModel<T>> GetBranchesByClinicIdAsync<T>(Guid clinicId);

    Task<ApiResponseModel> InsertBranchAsync<T>(T model);

    Task<ApiResponseModel> UpdateBranchAsync<T>(T model);

    Task<ApiResponseModel> DeleteDepartmentAsync(Guid id);

    Task<ApiResponseItemModel<T>> GetDepartmentByIdAsync<T>(Guid id);

    Task<ApiResponseListModel<T>> GetDepartmentsAsync<T>();

    Task<ApiResponseListModel<T>> GetDepartmentsByBranchIdAsync<T>(Guid branchId);

    Task<ApiResponseModel> InsertDepartmentAsync<T>(T model);

    Task<ApiResponseModel> UpdateDepartmentAsync<T>(T model);

    Task<ApiResponseModel> DeleteLanguageAsync(Guid id);

    Task<ApiResponseItemModel<T>> GetLanguageByIdAsync<T>(Guid id);

    Task<ApiResponseListModel<T>> GetLanguagesAsync<T>();

    Task<ApiResponseModel> InsertLanguageAsync<T>(T model);

    Task<ApiResponseModel> UpdateLanguageAsync<T>(T model);
}
