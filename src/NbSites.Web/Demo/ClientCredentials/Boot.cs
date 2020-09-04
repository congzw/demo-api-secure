using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace NbSites.Web.Demo.ClientCredentials
{
    public static class Boot
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void AddBasicAuth2(this IServiceCollection services)
        {
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IFooService, FooService>();
            services.AddScoped<IClientCredentialService, ClientCredentialService>();
        }
    }
}
