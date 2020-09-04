using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NbSites.Web.Demo.Shared
{
    public static class Boot
    {
        public static void AddShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFooService, FooService>();

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
        }
    }
}
