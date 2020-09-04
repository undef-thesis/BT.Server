using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BT.Application.Common;
using BT.Application.DTO;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Queries.GetOrganizedMeetings
{
    public class GetOrganizedMeetingsQueryHandler : IRequestHandler<GetOrganizedMeetingsQuery, IEnumerable<MeetingDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetOrganizedMeetingsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetingDto>> Handle(GetOrganizedMeetingsQuery query, CancellationToken cancellationToken)
        {
            var meetings = await _dataContext.Meetings.Include(x => x.Category)
                .Where(x => x.MeetingOrganizerId == query.UserId).ToListAsync();
            
            var mapped = _mapper.Map<IEnumerable<Meeting>, IEnumerable<MeetingDto>>(meetings);
            return mapped;
        }
    }
}