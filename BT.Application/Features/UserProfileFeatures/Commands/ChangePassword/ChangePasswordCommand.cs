using BT.Application.Features.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BT.Application.Features.UserProfileFeatures.Commands.ChangePassword
{
    public class ChangePasswordCommand : AuthRequest, IRequest
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}