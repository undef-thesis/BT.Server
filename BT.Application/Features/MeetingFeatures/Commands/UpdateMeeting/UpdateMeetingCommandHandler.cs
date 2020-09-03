using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Commands.UpdateMeeting
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommand>
    {
        private readonly IDataContext _dataContext;

        public UpdateMeetingCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<Unit> Handle(UpdateMeetingCommand command, CancellationToken cancellationToken)
        {
            var meeting = await _dataContext.Meetings.SingleOrDefaultAsync(
                x => x.Id == command.Id && x.MeetingOrganizerId == command.UserId);
            var address = await _dataContext.Address.SingleOrDefaultAsync(x => x.MeetingId == command.Id);

            if(meeting is null || address is null)
            {
                throw new UserIsNotMeetingOrganizerException();
            }

            meeting.Name = command.Name;
            meeting.Description = command.Description;

            address.Latitude = command.Latitude;
            address.Longitude = command.Longitude;
            address.Country = command.Country;
            address.Province = command.Province;
            address.City = command.City;
            address.Street = command.Street;

            _dataContext.Meetings.Update(meeting);
            _dataContext.Address.Update(address);

            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}