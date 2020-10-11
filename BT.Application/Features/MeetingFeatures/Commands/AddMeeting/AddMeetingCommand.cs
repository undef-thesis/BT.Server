using System;
using System.Collections.Generic;
using BT.Application.Features.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BT.Application.Features.MeetingFeatures.Commands.AddMeeting
{
    public class AddMeetingCommand : AuthRequest, IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxParticipants { get; set; }
        public DateTime Date { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Range { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public ICollection<IFormFile> Images { get; set; }
        public Guid CategoryId { get; set; }
    }
}