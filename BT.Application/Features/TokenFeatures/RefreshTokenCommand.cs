using BT.Application.DTO;
using MediatR;

namespace BT.Application.Features.TokenFeatures
{
    public class RefreshTokenCommand : IRequest<AuthDto>
    {
        public string RefreshToken { get; set; }
    }
}