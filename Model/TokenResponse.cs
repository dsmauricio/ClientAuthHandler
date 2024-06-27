namespace ClientAuthHandler.Model;

public class TokenResponse
{
    public string access_token { get; set; } = null!;
    public string token_type { get; set; } = null!;
    public int expires_in { get; set; }
}
