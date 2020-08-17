using MediatR;

namespace BT.Application.Features.TokenFeatures
{
    public class RevokeTokenCommand : IRequest
    {
        public string RefreshToken { get; set; }
    }
}