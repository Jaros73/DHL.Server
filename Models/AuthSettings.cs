namespace DHL.Server.Models;

public class AuthSettings
{
    public string Authority { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public Dictionary<string, string> Roles { get; set; } = new();

    public string GetRole()
    {
        return Roles.ContainsKey(ClientId) ? Roles[ClientId] : "Guest"; // Výchozí role
    }
}