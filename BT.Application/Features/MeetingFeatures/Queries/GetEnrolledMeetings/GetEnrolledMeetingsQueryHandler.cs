using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BT.Application.Common;
using BT.Application.DTO;
using BT.Application.Exceptions;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Queries.GetEnrolledMeetings
{
    public class GetEnrolledMeetingsQueryHandler : IRequestHandler<GetEnrolledMeetingsQuery, IEnumerable<MeetingDto>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetEnrolledMeetingsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetingDto>> Handle(GetEnrolledMeetingsQuery query, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == query.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var meetings = await _dataContext.Meetings.Include(x => x.Category).Include(x => x.Images).Include(x => x.Participants)
                .Where(x => x.Participants.Any(y => y.UserId == user.Id)).ToListAsync();

            if (meetings is null)
            {
                throw new MeetingNotFoundException();
            }

            var mapped = _mapper.Map<IEnumerable<Meeting>, IEnumerable<MeetingDto>>(meetings);

            return mapped;
        }
    }
}