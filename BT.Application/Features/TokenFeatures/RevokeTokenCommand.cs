using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.TokenFeatures
{
    public class RevokeTokenCommand : AuthRequest, IRequest
    {
        public string RefreshToken { get; set; }
    }
}