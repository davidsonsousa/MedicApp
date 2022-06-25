namespace MedicApp.SharedServices.Api;

public class ClinicManagementApiService : IClinicManagementApiService
{
    private readonly HttpClient httpClient;
    private readonly ILogger logger;
    private readonly string baseUrl = "https://localhost:7002"; // TODO: Move to settings file

    public ClinicManagementApiService(HttpClient httpClient, ILoggerFactory loggerFactory)
    {
        this.httpClient = httpClient;
        logger = loggerFactory.CreateLogger(nameof(ClinicManagementApiService));
    }

    public async Task<bool> DeleteClinicAsync(Guid id)
    {
        return await DeleteItemAsync("clinic", id);
    }

    public async Task<T> GetClinicByIdAsync<T>(Guid id)
    {
        return await GetItemByIdAsync<T>("clinic", id);
    }

    public async Task<IEnumerable<T>> GetClinicsAsync<T>()
    {
        return await GetItemsAsync<T>("clinic");
    }

    public async Task<bool> InsertClinicAsync<T>(T model)
    {
        return await InsertItemAsync("clinic", model);
    }

    public async Task<bool> UpdateClinicAsync<T>(T model)
    {
        return await UpdateItemAsync("clinic", model);
    }

    public async Task<bool> DeleteBranchAsync(Guid id)
    {
        return await DeleteItemAsync("branch", id);
    }

    public async Task<T> GetBranchByIdAsync<T>(Guid id)
    {
        return await GetItemByIdAsync<T>("branch", id);
    }

    public async Task<IEnumerable<T>> GetBranchesAsync<T>()
    {
        return await GetItemsAsync<T>("branch");
    }

    public async Task<bool> InsertBranchAsync<T>(T model)
    {
        return await InsertItemAsync("branch", model);
    }

    public async Task<bool> UpdateBranchAsync<T>(T model)
    {
        return await UpdateItemAsync("branch", model);
    }

    public async Task<bool> DeleteDepartmentAsync(Guid id)
    {
        return await DeleteItemAsync("department", id);
    }

    public async Task<T> GetDepartmentByIdAsync<T>(Guid id)
    {
        return await GetItemByIdAsync<T>("department", id);
    }

    public async Task<IEnumerable<T>> GetDepartmentsAsync<T>()
    {
        return await GetItemsAsync<T>("department");
    }

    public async Task<bool> InsertDepartmentAsync<T>(T model)
    {
        return await InsertItemAsync("department", model);
    }

    public async Task<bool> UpdateDepartmentAsync<T>(T model)
    {
        return await UpdateItemAsync("department", model);
    }

    private async Task<bool> DeleteItemAsync(string endpoint, Guid id)
    {
        var response = await httpClient.DeleteAsync($"{baseUrl}/{endpoint}/{id}");

        return response.IsSuccessStatusCode
               ? true
               : throw new HttpRequestException($"Delete operation failed. Status code: {response.StatusCode}");
    }

    private async Task<T> GetItemByIdAsync<T>(string endpoint, Guid id)
    {
        var response = await httpClient.GetFromJsonAsync<T>($"{baseUrl}/{endpoint}/{id}");

        if (response is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    private async Task<IEnumerable<T>> GetItemsAsync<T>(string endpoint)
    {
        var response = await httpClient.GetFromJsonAsync<IEnumerable<T>>($"{baseUrl}/{endpoint}");

        if (response is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    private async Task<bool> InsertItemAsync<T>(string endpoint, T model)
    {
        var response = await httpClient.PostAsJsonAsync($"{baseUrl}/{endpoint}", model);

        return response.IsSuccessStatusCode
               ? true
               : throw new HttpRequestException($"Post operation failed. Status code: {response.StatusCode}");
    }

    private async Task<bool> UpdateItemAsync<T>(string endpoint, T model)
    {
        var response = await httpClient.PutAsJsonAsync($"{baseUrl}/{endpoint}", model);

        return response.IsSuccessStatusCode
               ? true
               : throw new HttpRequestException($"Put operation failed. Status code: {response.StatusCode}");
    }

    //private async Task<string> PrepareClient()
    //{
    //    var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { userApiScope });
    //    logger.LogInformation($"access token: {accessToken}");
    //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //    return accessToken;
    //}
}
