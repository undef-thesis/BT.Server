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

namespace BT.Application.Features.MeetingFeatures.Queries.GetFilteredMeetings
{
    public class GetFilteredMeetingsQueryHandler : IRequestHandler<GetFilteredMeetingsQuery, IEnumerable<MeetingDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetFilteredMeetingsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetingDto>> Handle(GetFilteredMeetingsQuery query, CancellationToken cancellationToken)
        {
            var meetings = await _dataContext.Meetings
                .Include(x => x.Address).Include(x => x.Category).Include(x => x.Images)
                .Where(x => x.CategoryId == query.CategoryId ||
                        x.Address.City.ToLower() == query.City.ToLower() ||
                        x.Address.Country.ToLower() == query.Country.ToLower())
                        .ToListAsync();

            var mapped = _mapper.Map<IEnumerable<Meeting>, IEnumerable<MeetingDto>>(meetings);

            return mapped;
        }
    }
}