using BT.Application.DTO;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.UserProfileFeatures.Queries.GetUserProfile
{
    public class GetUserProfileQuery : AuthRequest, IRequest<UserPofileDto>
    {
        
    }
}