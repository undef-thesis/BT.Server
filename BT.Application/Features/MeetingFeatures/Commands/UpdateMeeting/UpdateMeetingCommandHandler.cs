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

            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Id == meeting.CategoryId);

            if (category is null)
            {
                throw new CategoryNotFoundException();
            }

            category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Id == command.CategoryId);


            meeting.UpdateMeeting(command.Name, command.Description, command.MaxParticipants, command.Date);
            address.UpdateAddress(command.Latitude, command.Longitude, command.Range, command.Country, 
                command.PostalCode, command.Province, command.City, command.Street);
            category.UpdateCategory(category.Name);

            _dataContext.Meetings.Update(meeting);
            _dataContext.Address.Update(address);
            _dataContext.Categories.Update(category);

            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}