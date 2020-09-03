using System;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Commands.DeleteMeeting
{
    public class DeleteMeetingCommand : AuthRequest, IRequest
    {
        public Guid Id { get; set; }
    }
}