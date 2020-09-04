using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NbSites.Web.Demo.Basic.Entities;
using NbSites.Web.Demo.Basic.Services;

namespace NbSites.Web.Demo.Basic.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Authenticate")]
        public async Task<IActionResult> Authenticate()
        {
            var mockPostArgs = new User() {Username = "test", Password = "test"};
            var user = await _userService.Authenticate(mockPostArgs.Username, mockPostArgs.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            //On successful authentication the Authenticate method returns the user details,
            //the client application should then include the base64 encoded user credentials
            //in the HTTP Authorization header of subsequent api requests to access secure endpoints.
            return Ok(user);
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("GetAll2")]
        public async Task<IActionResult> GetAll2()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}
