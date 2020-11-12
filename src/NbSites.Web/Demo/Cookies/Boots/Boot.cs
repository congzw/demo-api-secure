using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace NbSites.Web.Demo.Cookies.Boots
{
    public static class Boot
    {
        public static void AddMyCookies(this IServiceCollection services)
        {
            //services.AddAuthentication(MyCookie.CookieScheme) // Sets the default scheme to cookies
            services.AddAuthentication() // NOT Sets the default scheme to cookies
                .AddCookie(MyCookie.CookieScheme, options =>
                {
                    options.AccessDeniedPath = "/CookieAuth/AccessDenied";
                    options.LoginPath = "/CookieAuth/CookieLogin";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("NeedAdmin", policy =>
                {
                    policy.RequireRole("Admin");
                });

                options.AddPolicy("NeedMember", policy =>
                {
                    policy.RequireRole("Member");
                });
            });

            // Example of how to customize a particular instance of cookie options and
            // is able to also use other services.
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureMyCookie>();
        }
    }
}
