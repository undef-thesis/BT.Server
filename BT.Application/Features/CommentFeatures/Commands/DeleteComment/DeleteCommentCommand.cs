using System;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.CommentFeatures.Commands.DeleteComment
{
    public class DeleteCommentCommand : AuthRequest, IRequest
    {
        public Guid Id { get; set; }
    }
}