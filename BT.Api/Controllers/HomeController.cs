using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
    
        }

        [HttpGet]
        public string Get()
        {
            return "BT.Server works!";
        }
    }
}
