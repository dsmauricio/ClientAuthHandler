namespace ClientAuthHandler.Interfaces;

public interface IAuthService
{
    Task<string?> GetAccessTokenAsync();
}