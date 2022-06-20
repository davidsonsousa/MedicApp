namespace MedicApp.SharedServices.Api;

public interface IClinicManagementApiService
{
    Task<bool> DeleteItemAsync(Guid id);

    Task<T> GetItemByIdAsync<T>(Guid id);

    Task<IEnumerable<T>> GetItemsAsync<T>();

    Task<bool> InsertItemAsync<T>(T model);

    Task<bool> UpdateItemAsync<T>(T model);
}
