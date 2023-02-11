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

    public async Task<ApiResponseModel> DeleteClinicAsync(Guid id)
    {
        return await DeleteItemAsync("clinic", id);
    }

    public async Task<ApiResponseItemModel<T>> GetClinicByIdAsync<T>(Guid id)
    {
        return await GetItemByIdAsync<T>("clinic", id);
    }

    public async Task<ApiResponseListModel<T>> GetClinicsAsync<T>()
    {
        return await GetItemsAsync<T>("clinic");
    }

    public async Task<ApiResponseModel> InsertClinicAsync<T>(T model)
    {
        return await InsertItemAsync("clinic", model);
    }

    public async Task<ApiResponseModel> UpdateClinicAsync<T>(T model)
    {
        return await UpdateItemAsync("clinic", model);
    }

    public async Task<ApiResponseModel> DeleteBranchAsync(Guid id)
    {
        return await DeleteItemAsync("branch", id);
    }

    public async Task<ApiResponseItemModel<T>> GetBranchByIdAsync<T>(Guid id)
    {
        return await GetItemByIdAsync<T>("branch", id);
    }

    public async Task<ApiResponseListModel<T>> GetBranchesAsync<T>()
    {
        return await GetItemsAsync<T>("branch");
    }

    public async Task<ApiResponseListModel<T>> GetBranchesByClinicIdAsync<T>(Guid clinicId)
    {
        var response = await httpClient.GetFromJsonAsync<ApiResponseListModel<T>>($"{baseUrl}/branch/by-clinic/{clinicId}");

        if (response is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    public async Task<ApiResponseModel> InsertBranchAsync<T>(T model)
    {
        return await InsertItemAsync("branch", model);
    }

    public async Task<ApiResponseModel> UpdateBranchAsync<T>(T model)
    {
        return await UpdateItemAsync("branch", model);
    }

    public async Task<ApiResponseModel> DeleteDepartmentAsync(Guid id)
    {
        return await DeleteItemAsync("department", id);
    }

    public async Task<ApiResponseItemModel<T>> GetDepartmentByIdAsync<T>(Guid id)
    {
        return await GetItemByIdAsync<T>("department", id);
    }

    public async Task<ApiResponseListModel<T>> GetDepartmentsAsync<T>()
    {
        return await GetItemsAsync<T>("department");
    }

    public async Task<ApiResponseListModel<T>> GetDepartmentsByBranchIdAsync<T>(Guid branchId)
    {
        var response = await httpClient.GetFromJsonAsync<ApiResponseListModel<T>>($"{baseUrl}/department/by-branch/{branchId}");

        if (response is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    public async Task<ApiResponseModel> InsertDepartmentAsync<T>(T model)
    {
        return await InsertItemAsync("department", model);
    }

    public async Task<ApiResponseModel> UpdateDepartmentAsync<T>(T model)
    {
        return await UpdateItemAsync("department", model);
    }

    private async Task<ApiResponseModel> DeleteItemAsync(string endpoint, Guid id)
    {
        var response = await httpClient.DeleteAsync($"{baseUrl}/{endpoint}/{id}");

        return response.IsSuccessStatusCode
               ? new ApiResponseModel($"{endpoint.Humanize(LetterCasing.Title)} deleted successfully!")
               : throw new HttpRequestException($"Delete operation failed. Status code: {response.StatusCode}");
    }

    private async Task<ApiResponseItemModel<T>> GetItemByIdAsync<T>(string endpoint, Guid id)
    {
        var response = await httpClient.GetFromJsonAsync<ApiResponseItemModel<T>>($"{baseUrl}/{endpoint}/{id}");

        if (response is null || response.HasError || response.Item is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    private async Task<ApiResponseListModel<T>> GetItemsAsync<T>(string endpoint)
    {
        var response = await httpClient.GetFromJsonAsync<ApiResponseListModel<T>>($"{baseUrl}/{endpoint}");

        if (response is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    private async Task<ApiResponseModel> InsertItemAsync<T>(string endpoint, T model)
    {
        var response = await httpClient.PostAsJsonAsync($"{baseUrl}/{endpoint}", model);

        return response.IsSuccessStatusCode
               ? new ApiResponseModel($"{endpoint.Humanize(LetterCasing.Title)} added successfully!")
               : throw new HttpRequestException($"Post operation failed. Status code: {response.StatusCode}");
    }

    private async Task<ApiResponseModel> UpdateItemAsync<T>(string endpoint, T model)
    {
        var response = await httpClient.PutAsJsonAsync($"{baseUrl}/{endpoint}", model);

        return response.IsSuccessStatusCode
               ? new ApiResponseModel($"{endpoint.Humanize(LetterCasing.Title)} updated successfully!")
               : throw new HttpRequestException($"Put operation failed. Status code: {response.StatusCode}");
    }

    public async Task<ApiResponseModel> DeleteLanguageAsync(Guid id)
    {
        return await DeleteItemAsync("language", id);
    }

    public async Task<ApiResponseItemModel<T>> GetLanguageByIdAsync<T>(Guid id)
    {
        return await GetItemByIdAsync<T>("language", id);
    }

    public async Task<ApiResponseListModel<T>> GetLanguagesAsync<T>()
    {
        return await GetItemsAsync<T>("language");
    }

    public async Task<ApiResponseModel> InsertLanguageAsync<T>(T model)
    {
        return await InsertItemAsync("language", model);
    }

    public async Task<ApiResponseModel> UpdateLanguageAsync<T>(T model)
    {
        return await UpdateItemAsync("language", model);
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
