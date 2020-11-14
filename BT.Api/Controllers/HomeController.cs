using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        /// <summary>
        /// Check server
        /// </summary>
        /// <returns>String with text information about working server</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("test-server")]
        public IActionResult Get()
        {
            return Ok("BT.Server works!");
        }

        /// <summary>
        /// Check server with auth
        /// </summary>
        /// <returns>String with text information about working server and successful authorization</returns>
        [HttpGet]
        [Authorize]
        [Route("test-auth")]
        public IActionResult GetAuth()
        {
            return Ok("BT.Server with auth works!");
        }
    }
}
