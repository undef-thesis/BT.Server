using System;
using System.Collections.Generic;
using BT.Application.DTO;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Queries.GetFilteredMeetings
{
    public class GetFilteredMeetingsQuery : IRequest<IEnumerable<MeetingDto>>
    {
        public Guid CategoryId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}