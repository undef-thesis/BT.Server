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

namespace BT.Application.Features.MeetingFeatures.Queries.GetMeetings
{
    public class GetMeetingsQueryHandler : IRequestHandler<GetMeetingsQuery, IEnumerable<MeetingDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetMeetingsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<MeetingDto>> Handle(GetMeetingsQuery query, CancellationToken cancellationToken)
        {
            var meetings = await _dataContext.Meetings.Include(x => x.Category)
                .Where(x => x.Address.City == query.City).ToListAsync();

            var mapped = _mapper.Map <IEnumerable<Meeting>, IEnumerable<MeetingDto>>(meetings);

            return mapped;
        }
    }
}