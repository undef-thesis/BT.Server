using System.Threading.Tasks;
using BT.Application.DTO;
using BT.Application.Features.UserProfileFeatures.Commands.AddAvatar;
using BT.Application.Features.UserProfileFeatures.Commands.ChangePassword;
using BT.Application.Features.UserProfileFeatures.Commands.DeleteAccount;
using BT.Application.Features.UserProfileFeatures.Queries.GetUserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class AccountController : ApiBaseController
    {
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>CategoriesDto</returns>
        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var profile = await Execute(new GetUserProfileQuery());

            return Ok(profile);
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>CategoriesDto</returns>
        [HttpPost]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> AddAvatar([FromForm] AddAvatarCommand command)
        {
            await Execute(command);

            return Ok();
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Authorize]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            await Execute(command);

            return Ok();
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [Route("delete-account")]
        public async Task<IActionResult> DeleteAccount()
        {
            await Execute(new DeleteAccountCommand());

            return Ok();
        }
    }
}