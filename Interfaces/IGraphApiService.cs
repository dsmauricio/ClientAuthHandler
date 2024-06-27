namespace ClientAuthHandler.Interfaces;

public interface IGraphApiService
{
    Task<string> GetUsersAsync();
}