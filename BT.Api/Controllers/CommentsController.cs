using System;
using System.Threading.Tasks;
using BT.Application.Features.CommentFeatures.Commands.AddComment;
using BT.Application.Features.CommentFeatures.Commands.DeleteComment;
using BT.Application.Features.CommentFeatures.Commands.UpdateComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class CommentsController : ApiBaseController
    {
        public CommentsController()
        {
            
        }

        /// <summary>
        /// Add new comment to the meeting
        /// </summary>
        /// <param name="command">AddCommentCommand</param> 
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody]AddCommentCommand command)
        {
            await Execute(command);

            return Ok();
        }

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="id">Comment id</param> 
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody]UpdateCommentCommand command, Guid id)
        {
            command.Id = id;
            await Execute(command);

            return Ok();
        }

        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="id">Comment id</param> 
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Execute(new DeleteCommentCommand { Id = id });

            return NoContent();
        }
    }
}