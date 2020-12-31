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
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == command.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var meeting = await _dataContext.Meetings.Include(x => x.Participants).SingleOrDefaultAsync(x => x.Id == command.Id);

            if (meeting is null)
            {
                throw new MeetingNotFoundException();
            }

            var isUserEnrolled = meeting.Participants.SingleOrDefault(x => x.UserId == command.UserId);

            // TODO: return error???
            if (isUserEnrolled != null || meeting.MeetingOrganizerId == command.UserId)
            {
                // return Unit.Value;
                throw new UserAlreadyBelongsToTheMeetingException();
            }

            if (meeting.ParticipantCount == meeting.MaxParticipants)
            {
                throw new MeetingHasNotFreeSlotsException();
                // return Unit.Value;
            }

            meeting.AddParticipantToCounter();

            var userMeeting = new UserMeeting(user.Id, user, meeting.Id, meeting);

            await _dataContext.UserMeeting.AddAsync(userMeeting);
            await _dataContext.SaveChangesAsync();

            

            return Unit.Value;
        }
    }
}