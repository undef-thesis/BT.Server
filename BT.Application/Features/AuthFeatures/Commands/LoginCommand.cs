using System;
using MediatR;

namespace BT.Application.Features.AuthFeatures.Commands
{
    public class LoginCommand : IRequest
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}