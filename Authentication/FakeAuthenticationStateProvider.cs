namespace DHL.Server.Authentication
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Components.Authorization;

    public class FakeAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Vrátí uživatele jako "přihlášeného"
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, "testuser"),
            new Claim(ClaimTypes.Role, "admin")
        }, "Fake authentication");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }

}
