using System.Collections.Generic;
using BT.Application.DTO;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Queries.GetOrganizedMeetings
{
    public class GetOrganizedMeetingsQuery : AuthRequest, IRequest<IEnumerable<MeetingDto>>
    {

    }
}