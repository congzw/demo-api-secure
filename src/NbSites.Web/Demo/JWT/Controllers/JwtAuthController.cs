using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NbSites.Web.Demo.JWT.Helpers;
using NbSites.Web.Demo.Shared;

namespace NbSites.Web.Demo.JWT.Controllers
{
    [Authorize]
    [Route("Api/JwtAuth")]
    public class JwtAuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AppSettings _appSettings;

        public JwtAuthController(IAuthService authService, IOptions<AppSettings> appSettings)
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
            
            //On successful authentication the Authenticate method generates a JWT(JSON Web Token)
            //using the JwtSecurityTokenHandler class that generates a token that is digitally signed using a secret key stored in appsettings.json.
            //The JWT token is returned to the client application which then must include it in the HTTP Authorization header of subsequent web api requests for authentication.
            var jwtSecurityTokenHelper = new JwtSecurityTokenHelper();
            var token = jwtSecurityTokenHelper.GenerateToken(generateTokenArgs);
            return Ok(token);
        }
    }
}
