using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Commands.JoinMeeting
{
    public class JoinMeetingCommandHandler : IRequestHandler<JoinMeetingCommand>
    {
        private readonly IDataContext _dataContext;

        public JoinMeetingCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(JoinMeetingCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.Include(x => x.EnrolledMeetings)
                .ThenInclude(x => x.Meeting).SingleOrDefaultAsync(x => x.Id == command.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var meeting = await _dataContext.Meetings.SingleOrDefaultAsync(x => x.Id == command.Id);

            if (meeting is null)
            {
                throw new MeetingNotFoundException();
            }

            var isUserEnrolled = user.EnrolledMeetings.SingleOrDefault(x => x.UserId == command.UserId);

            if (isUserEnrolled != null)
            {
                throw new UserAlreadyBelongsToTheMeetingException();
            }

            var userMeeting = new UserMeeting(user.Id, user, meeting.Id, meeting);

            await _dataContext.UserMeeting.AddAsync(userMeeting);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}