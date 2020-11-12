using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NbSites.Web.Demo.Shared;

namespace NbSites.Web.Demo.Cookies.Controllers
{
    public class CookieAuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly AppSettings _appSettings;

        public CookieAuthController(IAuthService authService, IOptions<AppSettings> appSettings)
        {
            _authService = authService;
            _appSettings = appSettings.Value;
        }
        
        public IActionResult CookieLogin()
        {
            return View();
        }

        public async Task<IActionResult> Authenticate()
        {
            //for demo simplicity, use get and no args
            //todo: authenticate validation
            var success = _authService.Validate("test", "test");
            if (!success)
            {
                //return BadRequest(new { message = "Username or password is incorrect" });
            }

            var claims = new List<Claim>
            {
                new Claim("user", "test"),
                new Claim("role", "Member")
            };

            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));
            return Redirect("/");
        }

        [Authorize(AuthenticationSchemes = MyCookie.CookieScheme)]
        public IActionResult MyClaims()
        {
            return View();
        }

        [Authorize(Policy = "NeedAdmin", AuthenticationSchemes = MyCookie.CookieScheme)]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Policy = "NeedMember", AuthenticationSchemes = MyCookie.CookieScheme)]
        public IActionResult Member()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
