using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class HomeController : ApiBaseController
    {
        public HomeController()
        {

        }

        /// <summary>
        /// Check server
        /// </summary>
        /// <returns>String with text information about working server</returns>
        [HttpGet]
        public string Get()
        {
            return "BT.Server works!";
        }
    }
}
