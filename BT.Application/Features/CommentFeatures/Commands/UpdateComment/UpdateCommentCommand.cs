using System;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.CommentFeatures.Commands.UpdateComment
{
    public class UpdateCommentCommand : AuthRequest, IRequest
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}