using System;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.CommentFeatures.Commands.AddComment
{
    public class AddCommentCommand : AuthRequest, IRequest
    {
        public Guid MeetingId { get; set; }
        public string Content { get; set; }
    }
}