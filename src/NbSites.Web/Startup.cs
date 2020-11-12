using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NbSites.Web.Boots;
using NbSites.Web.Demo.Basic.Boots;
using NbSites.Web.Demo.Cookies.Boots;
using NbSites.Web.Demo.JWT.Boots;
using NbSites.Web.Demo.Shared;

namespace NbSites.Web
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(ILogger<Startup> logger, IHostingEnvironment env, IConfiguration configuration)
        {
            _logger = logger;
            _env = env;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddShared(_configuration);

            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var scheme = appSettings.Scheme;
            if (scheme == "Basic")
            {
                services.AddMyBasicAuth();
            }
            else if (scheme == "Bearer")
            {
                //Bearer
                services.AddMyJWT(_configuration);
            }


            //MyCookies
            services.AddMyCookies();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMyStaticFiles(_env, _logger);

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "route_root",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
