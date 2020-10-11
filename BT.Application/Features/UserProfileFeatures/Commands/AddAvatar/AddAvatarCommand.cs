using BT.Application.Features.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BT.Application.Features.UserProfileFeatures.Commands.AddAvatar
{
    public class AddAvatarCommand : AuthRequest, IRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IFormFile Avatar { get; set; }
    }
}