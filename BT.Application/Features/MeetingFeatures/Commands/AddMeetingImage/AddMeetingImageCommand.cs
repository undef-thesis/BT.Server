using System;
using System.Collections.Generic;
using BT.Application.Features.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BT.Application.Features.MeetingFeatures.Commands.AddMeetingImage
{
    public class AddMeetingImageCommand : AuthRequest, IRequest
    {
        public Guid MeetingId { get; set; }
        public ICollection<IFormFile> Images { get; set; }
    }
}