using System;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Commands.JoinMeeting
{
    public class JoinMeetingCommand : AuthRequest, IRequest
    {
        public Guid Id { get; set; }
    }
}