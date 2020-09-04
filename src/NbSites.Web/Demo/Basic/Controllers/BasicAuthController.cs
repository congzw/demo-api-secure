using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NbSites.Web.Demo.Basic.Helpers;
using NbSites.Web.Demo.JWT.Helpers;
using NbSites.Web.Demo.Shared;

namespace NbSites.Web.Demo.Basic.Controllers
{
    [Authorize]
    [Route("Api/BasicAuth")]
    public class BasicAuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AppSettings _appSettings;

        public BasicAuthController(IAuthService authService, IOptions<AppSettings> appSettings)
        {
            _authService = authService;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpGet("Authenticate")]
        public IActionResult Authenticate()
        {
            //for demo simplicity, use get and no args
            //todo: authenticate validation
            var success = _authService.Validate("test", "test");
            if (!success)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            //todo: get more client claim infos
            var generateTokenArgs = new GenerateTokenArgs();
            generateTokenArgs.Id = _appSettings.Id;
            generateTokenArgs.Secret = _appSettings.Secret;

            var basicAuthTokenHelper = new BasicAuthTokenHelper();
            var generateToken = basicAuthTokenHelper.GenerateToken(generateTokenArgs.Id, generateTokenArgs.Secret);
            return Ok(generateToken);
        }
    }
}
