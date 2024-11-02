using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using example_back.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace conflict_back.Controllers
{
    [Route("/main")]
    [ApiController]
    [Authorize]
    public class MainPageController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public MainPageController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult GetProtectedData()
        {

            return Ok("This is protected data.");
        }
    }
}