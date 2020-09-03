using BT.Application.DTO;
using MediatR;

namespace BT.Application.Features.AuthFeatures.Commands.Login
{
    public class LoginCommand : IRequest<AuthDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}