using System;
using BT.Application.Features.Behaviours;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Commands.AddMeeting
{
    public class AddMeetingCommand : AuthRequest, IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxParticipants { get; set; }
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Category { get; set; }
    }
}