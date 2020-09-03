using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BT.Application.Services.Auth;
using BT.Application.Features.AuthFeatures.Commands.Login;
using BT.Application.Features.TokenFeatures.Commands.RefreshToken;
using BT.Application.Features.TokenFeatures.Commands.RevokeToken;
using BT.Application.Features.AuthFeatures.Commands.Register;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class IdentityController : ApiBaseController
    {
        private readonly IAuthTokenCache _authTokensCache;
        
        public IdentityController(IAuthTokenCache authTokensCache)
        {
            _authTokensCache = authTokensCache;
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
            await Execute(command);

            return Created($"users/{command.Email}", new object());
        }

        /// <summary>
        /// Login user to application
        /// </summary>
        /// <param name="command">LoginCommand</param> 
        /// <returns>Return AuthDto</returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginCommand command)
        {
            var token = await Execute(command);

            return Ok(token);
        }

        /// <summary>
        /// Refresh user token
        /// </summary>
        /// <param name="command">RefreshTokenCommand</param> 
        /// <returns>Return new token</returns>
        [HttpPost]
        [Route("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenCommand command)
        {
            var token = await Execute(command);

            return Ok(token);
        }

        /// <summary>
        /// Revoke refresh user token
        /// </summary>
        /// <param name="command">RevokeTokenCommand</param> 
        /// <returns>Revoke refresh token</returns>
        [HttpPost]
        [Route("revoke-token")]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody]RevokeTokenCommand command)
        {
            await Execute(command);

            return Ok();
        }
    }
}