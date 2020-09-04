using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BT.Application.Common;
using BT.Application.DTO;
using BT.Application.Exceptions;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Queries.GetMeetingDetails
{
    public class GetMeetingDetailsQueryHandler : IRequestHandler<GetMeetingDetailsQuery, MeetingDetailsDto>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetMeetingDetailsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<MeetingDetailsDto> Handle(GetMeetingDetailsQuery query, CancellationToken cancellationToken)
        {
            var meetingDetails = await _dataContext.Meetings.Include(x => x.Address)
                .Include(x => x.Comments).Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == query.Id);

            if (meetingDetails is null)
            {
                throw new MeetingNotFoundException();
            }

            return _mapper.Map<Meeting, MeetingDetailsDto>(meetingDetails);
        }
    }
}