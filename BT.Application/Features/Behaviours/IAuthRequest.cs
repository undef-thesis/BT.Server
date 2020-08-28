using System;
using MediatR;

namespace BT.Application.Features.Behaviours
{
    public class AuthRequest : IRequest
    {
        public Guid UserId { get; set; }
    }
}