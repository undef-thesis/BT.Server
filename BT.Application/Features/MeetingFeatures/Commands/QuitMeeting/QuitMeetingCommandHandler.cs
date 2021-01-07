using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Commands.QuitMeeting
{
    public class QuitMeetingCommandHandler : IRequestHandler<QuitMeetingCommand>
    {
        private readonly IDataContext _dataContext;

        public QuitMeetingCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(QuitMeetingCommand command, CancellationToken cancellationToken)
        {
            var userMeeting = await _dataContext.UserMeeting.Include(x => x.Meeting)
                .Where(x => x.UserId == command.UserId && x.MeetingId == command.Id && x.Meeting.MeetingOrganizerId != command.UserId).FirstAsync();

            if (userMeeting is null)
            {
                throw new UserNotBelongToTheMeetingException();
            }

            userMeeting.Meeting.RemoveParticipantFromCounter();

            _dataContext.UserMeeting.Remove(userMeeting);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}