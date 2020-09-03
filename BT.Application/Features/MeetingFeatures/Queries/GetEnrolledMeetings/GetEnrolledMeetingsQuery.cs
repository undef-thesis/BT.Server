using System.Collections.Generic;
using BT.Application.DTO;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Queries.GetEnrolledMeetings
{
    public class GetEnrolledMeetingsQuery : AuthRequest, IRequest<IEnumerable<MeetingDto>>
    {
        
    }
}