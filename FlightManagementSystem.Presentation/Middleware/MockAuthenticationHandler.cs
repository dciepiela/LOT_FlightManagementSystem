using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

public class MockAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public MockAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var identity = new ClaimsIdentity("mock");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "mock");
        return await Task.FromResult(AuthenticateResult.Success(ticket));
    }
}