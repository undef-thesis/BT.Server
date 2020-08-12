using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BT.Application.Features.AuthFeatures.Commands;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class IdentityController : ApiBaseController
    {
        public IdentityController()
        {

        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="command">RegisterCommand</param> 
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterCommand command)
        {
            await Mediator.Send(command);

            return Created($"users/{command.Email}", new object());
        }
    }
}