using System;
using System.Collections.Generic;
using BT.Application.DTO;
using MediatR;

namespace BT.Application.Features.MeetingFeatures.Queries.GetMeetings
{
    public class GetMeetingsQuery : IRequest<IEnumerable<MeetingDto>>
    {
        public Guid Id { get; set; }
        public string City { get; set; }
    }
}