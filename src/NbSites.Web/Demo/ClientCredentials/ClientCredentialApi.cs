using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NbSites.Web.Demo.ClientCredentials
{
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientCredentialService _clientCredentialService;

        public ClientController(IClientCredentialService clientCredentialService)
        {
            _clientCredentialService = clientCredentialService;
        }

        [HttpGet("Authenticate")]
        public async Task<IActionResult> Authenticate()
        {
            //for easy test, use get and no args
            var client = await _clientCredentialService.Authenticate("test", "test");

            if (client == null)
                return BadRequest(new { message = "client authenticate failed" });

            //On successful authentication the Authenticate method returns the user details,
            //the client application should then include the base64 encoded user credentials
            //in the HTTP Authorization header of subsequent api requests to access secure endpoints.
            return Ok(client);
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] IFooService fooService)
        {
            return Ok(fooService.GetAll());
        }

        [HttpGet("GetAll2")]
        public IActionResult GetAll2([FromServices] IFooService fooService)
        {
            return Ok(fooService.GetAll());
        }
    }
}
