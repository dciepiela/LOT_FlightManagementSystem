using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FlightManagementSystem.Presentation.Middleware
{
    public static class MockAuthenticationExtensions
    {
        public static AuthenticationBuilder AddMockAuthentication(this AuthenticationBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<JwtBearerOptions>, JwtBearerPostConfigureOptions>());
            return builder.AddScheme<AuthenticationSchemeOptions, MockAuthenticationHandler>("Mock", options => { });
        }
    }
}
