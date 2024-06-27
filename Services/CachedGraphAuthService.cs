using ClientAuthHandler.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ClientAuthHandler.Services
{
    public class CachedGraphAuthService : IAuthService
    {
        private readonly IAuthService _authService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CachedGraphAuthService> _logger;

        public CachedGraphAuthService(IAuthService authService, ILogger<CachedGraphAuthService> logger, IMemoryCache memoryCache)
        {
            _authService = authService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task<string?> GetAccessTokenAsync()
        {
            _logger.LogInformation("Invoking access token from CachedGraphAuthService");
            var accessToken = await _memoryCache.GetOrCreateAsync("AccessToken", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(50);
                return await _authService.GetAccessTokenAsync();
            });

            return accessToken;
        }
    }
}
