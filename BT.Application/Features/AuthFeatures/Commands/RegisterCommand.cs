
using MediatR;

namespace BT.Application.Features.AuthFeatures.Commands
{
    public class RegisterCommand : IRequest
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}