using System;
using BT.Application.DTO;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Queries.GetMeetingDetails
{
    public class GetMeetingDetailsQuery : AuthRequest, IRequest<MeetingDetailsDto>
    {
        public Guid Id { get; set; }
    }
}