using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Web.Demo.Basic.Helpers;
using NbSites.Web.Demo.Basic.Services;

namespace NbSites.Web.Demo.Basic.Boots
{
    public static class Boot
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void AddBasicAuth(this IServiceCollection services)
        {
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
        }
    }
}
