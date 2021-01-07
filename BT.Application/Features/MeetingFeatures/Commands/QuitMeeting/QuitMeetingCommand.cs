using System;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Commands.QuitMeeting
{
    public class QuitMeetingCommand : AuthRequest, IRequest
    {
        public Guid Id { get; set; }
    }
}