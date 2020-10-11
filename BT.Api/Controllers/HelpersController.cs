using System;
using System.Threading.Tasks;
using BT.Application.Features.GlobalData.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class HelpersController : ApiBaseController
    {
        /// <summary>
        /// City suggest
        /// </summary>
        /// <returns>Return Searched meetings</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("city-suggest")]
        public async Task<IActionResult> CitySuggest([FromQuery] string lookingCity)
        {
            var searchedMeetings = await Execute(new GetLookingCitiesQuery
            {
                LookingCity = lookingCity ?? String.Empty
            });

            return Ok(searchedMeetings);
        }
    }
}