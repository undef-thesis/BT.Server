using System;
using System.Threading.Tasks;
using BT.Application.Features.MeetingFeatures.Commands.AddMeeting;
using BT.Application.Features.MeetingFeatures.Commands.DeleteMeeting;
using BT.Application.Features.MeetingFeatures.Commands.JoinMeeting;
using BT.Application.Features.MeetingFeatures.Commands.UpdateMeeting;
using BT.Application.Features.MeetingFeatures.Queries.GetEnrolledMeetings;
using BT.Application.Features.MeetingFeatures.Queries.GetMeetingDetails;
using BT.Application.Features.MeetingFeatures.Queries.GetMeetings;
using BT.Application.Features.MeetingFeatures.Queries.GetOrganizedMeetings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class MeetingsController : ApiBaseController
    {
        public MeetingsController()
        {

        }

        /// <summary>
        /// Get meetings and filter with param
        /// </summary>
        /// <param name="city">City name filter</param> 
        /// <returns>MeetingsDto</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> GetMeetings(string city)
        {
            var meetingDetails = await Execute(new GetMeetingsQuery { City = city });

            return Ok(meetingDetails);
        }

        /// <summary>
        /// Get meeting details
        /// </summary>
        /// <param name="id">Meeting id</param> 
        /// <returns>Return MeetingDto with address</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var meetingDetails = await Execute(new GetMeetingDetailsQuery { Id = id });

            return Ok(meetingDetails);
        }

        /// <summary>
        /// Get organized meetings
        /// </summary>
        /// <returns>Return MeetingsDto</returns>
        [HttpGet]
        [Authorize]
        [Route("organized")]
        public async Task<IActionResult> GetOrganized()
        {
            var organizedMeetings = await Execute(new GetOrganizedMeetingsQuery());

            return Ok(organizedMeetings);
        }

        /// <summary>
        /// Get enrolled meetings
        /// </summary>
        /// <returns>Return MeetingsDto</returns>
        [HttpGet]
        [Authorize]
        [Route("enrolled")]
        public async Task<IActionResult> GetEnrolled()
        {
            var ExecutedMeetings = await Execute(new GetEnrolledMeetingsQuery());

            return Ok(ExecutedMeetings);
        }

        /// <summary>
        /// Create new meeting
        /// </summary>
        /// <param name="command">AddMeetingCommand</param> 
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AddMeetingCommand command)
        {
            await Execute(command);

            return Ok();
        }

        /// <summary>
        /// Join to meeting
        /// </summary>
        /// <param name="command">JoinMeetingCommand</param> 
        /// <returns></returns>
        [HttpPost]
        [Route("join")]
        [Authorize]
        public async Task<IActionResult> Join([FromBody] JoinMeetingCommand command)
        {
            await Execute(command);

            return Ok();
        }

        /// <summary>
        /// Update meeting
        /// </summary>
        /// <param name="id">Meeting id</param> 
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateMeetingCommand command, Guid id)
        {
            command.Id = id;
            await Execute(command);

            return Ok();
        }

        /// <summary>
        /// Delete meeting
        /// </summary>
        /// <param name="id">Meeting id</param> 
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Execute(new DeleteMeetingCommand { Id = id });

            return NoContent();
        }
    }
}