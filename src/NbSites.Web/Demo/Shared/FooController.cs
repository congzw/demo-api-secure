using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NbSites.Web.Demo.Shared
{
    [Authorize]
    [Route("api/foo")]
    public class FooController : ControllerBase
    {
        private readonly IFooService _fooService;

        public FooController(IFooService fooService)
        {
            _fooService = fooService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //use Postman Test With Headers:
            //1 Authorization: Bearer {TheToken}
            //2 Authorization: Basic {TheToken}
            return Ok(_fooService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("GetAll2")]
        public IActionResult GetAll2()
        {
            return Ok(_fooService.GetAll());
        }
    }
}
