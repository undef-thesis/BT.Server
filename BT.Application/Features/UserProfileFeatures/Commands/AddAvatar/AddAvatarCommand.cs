using BT.Application.Features.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BT.Application.Features.UserProfileFeatures.Commands.AddAvatar
{
    public class AddAvatarCommand : AuthRequest, IRequest
    {
        public IFormFile Avatar { get; set; }
    }
}