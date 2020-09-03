using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Commands.DeleteMeeting
{
    public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommand>
    {
        private readonly IDataContext _dataContext;

        public DeleteMeetingCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(DeleteMeetingCommand command, CancellationToken cancellationToken)
        {            
            var meeting = await _dataContext.Meetings.SingleOrDefaultAsync(
                x => x.Id == command.Id && x.MeetingOrganizerId == command.UserId);

            if (meeting is null)
            {
                throw new UserIsNotMeetingOrganizerException();
            }

            _dataContext.Meetings.Remove(meeting);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}