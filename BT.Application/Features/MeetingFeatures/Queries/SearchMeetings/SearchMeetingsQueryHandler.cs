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

namespace BT.Application.Features.MeetingFeatures.Queries.SearchMeetings
{
    public class SearchMeetingsQueryHandler : IRequestHandler<SearchMeetingsQuery, IEnumerable<MeetingDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public SearchMeetingsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetingDto>> Handle(SearchMeetingsQuery query, CancellationToken cancellationToken)
        {
            string[] words = query.Term.Split(" ");
 
            var meetings = await _dataContext.Meetings
                .Include(x => x.Address).Include(x => x.Category).Include(x => x.Images)
                .Where(x => x.Address.City == query.City || x.Address.Country == query.Country)
                .ToListAsync();

            var searchedMeetings = new List<Meeting>();

            foreach (var meeting in meetings)
            {
                foreach (var word in words)
                {
                    if (meeting.Name.ToLower().Contains(word.ToLower()))
                    {
                        searchedMeetings.Add(meeting);
                    }
                }
            }
 
            var mapped = _mapper.Map<IEnumerable<Meeting>, IEnumerable<MeetingDto>>(searchedMeetings);

            return mapped;
        }
    }
}