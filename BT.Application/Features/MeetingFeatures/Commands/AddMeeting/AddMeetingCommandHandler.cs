using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Commands.AddMeeting
{
    public class AddMeetingCommandHandler : IRequestHandler<AddMeetingCommand>
    {
        private readonly IDataContext _dataContext;

        public AddMeetingCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(AddMeetingCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == command.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            command.Category = command.Category.ToLowerInvariant();
            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Name == command.Category);

            if (category is null)
            {
                throw new CategoryNotFoundException();
            }

            var meeting = new Meeting(command.Name, command.Description, command.MaxParticipants, 
                command.Date, user.Id, category.Id);
            var address = new Address(command.Latitude, command.Longitude, command.Country,
                command.Province, command.City, command.Street, meeting.Id);

            await _dataContext.Meetings.AddAsync(meeting);
            await _dataContext.Address.AddAsync(address);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}