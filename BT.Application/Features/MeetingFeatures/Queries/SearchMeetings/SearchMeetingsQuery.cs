using System.Collections.Generic;
using BT.Application.DTO;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Queries.SearchMeetings
{
    public class SearchMeetingsQuery : IRequest<IEnumerable<MeetingDto>>
    {
        public string Term { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}