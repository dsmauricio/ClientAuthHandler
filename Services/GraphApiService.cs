using ClientAuthHandler.Interfaces;

namespace ClientAuthHandler.Services;

public class GraphApiService : IGraphApiService
{
    private readonly HttpClient _httpClient;

    public GraphApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetUsersAsync()
    {
        var response = await _httpClient.GetAsync("users");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }
}
