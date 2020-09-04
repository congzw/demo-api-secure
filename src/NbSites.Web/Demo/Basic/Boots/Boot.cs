using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using NbSites.Web.Demo.Basic.Helpers;

namespace NbSites.Web.Demo.Basic.Boots
{
    public static class Boot
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void AddMyBasicAuth(this IServiceCollection services)
        {
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }
    }
}
