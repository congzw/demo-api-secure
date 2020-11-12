using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace NbSites.Web.Demo.Cookies
{
    public class MyCookie
    {
        public const string CookieScheme = "MyCookie";
    }

    // Example of how to customize a particular instance of cookie options and
    // is able to also use other services.
    internal class ConfigureMyCookie : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        // You can inject services here
        public ConfigureMyCookie()
        {
        }

        public void Configure(string name, CookieAuthenticationOptions options)
        {
            // Only configure the schemes you want
            if (name == MyCookie.CookieScheme)
            {
                // options.LoginPath = "/someotherpath";
            }
        }

        public void Configure(CookieAuthenticationOptions options) => Configure(Options.DefaultName, options);
    }
}
