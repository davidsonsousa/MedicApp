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

    public async Task<bool> DeleteItemAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"{baseUrl}/clinic/{id}");

        return response.IsSuccessStatusCode
               ? true
               : throw new HttpRequestException($"Delete operation failed. Status code: {response.StatusCode}");
    }

    public async Task<T> GetItemByIdAsync<T>(Guid id)
    {
        var response = await httpClient.GetFromJsonAsync<T>($"{baseUrl}/clinic/{id}");

        if (response is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    public async Task<IEnumerable<T>> GetItemsAsync<T>()
    {
        var response = await httpClient.GetFromJsonAsync<IEnumerable<T>>($"{baseUrl}/clinic");

        if (response is null)
        {
            throw new HttpRequestException($"Get operation failed. Status code: 404");
        }

        return response;
    }

    public async Task<bool> InsertItemAsync<T>(T model)
    {
        var response = await httpClient.PostAsJsonAsync($"{baseUrl}/clinic", model);

        return response.IsSuccessStatusCode
               ? true
               : throw new HttpRequestException($"Insert operation failed. Status code: {response.StatusCode}");
    }

    public async Task<bool> UpdateItemAsync<T>(T model)
    {
        var response = await httpClient.PutAsJsonAsync($"{baseUrl}/clinic", model);

        return response.IsSuccessStatusCode
               ? true
               : throw new HttpRequestException($"Insert operation failed. Status code: {response.StatusCode}");
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
