using ClientAuthHandler.Interfaces;
using ClientAuthHandler.Model;
using ClientAuthHandler.Settings;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ClientAuthHandler.Services;

public class GraphAuthService : IAuthService
{
    private readonly GraphSettings _graphSettings;
    private readonly HttpClient _httpClient;
    private readonly ILogger<GraphAuthService> _logger;

    public GraphAuthService(IOptions<GraphSettings> graphSettings, ILogger<GraphAuthService> logger, HttpClient httpClient)
    {
        _graphSettings = graphSettings.Value;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        _logger.LogInformation("Invoking access token from GraphAuthService");
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://login.microsoftonline.com/{_graphSettings.TenantId}/oauth2/v2.0/token");
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = _graphSettings.ClientId,
            ["scope"] = _graphSettings.Scope,
            ["client_secret"] = _graphSettings.ClientSecret,
            ["grant_type"] = "client_credentials"
        });

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        var token = JsonSerializer.Deserialize<TokenResponse>(responseContent);

        return token?.access_token;
    }
}
