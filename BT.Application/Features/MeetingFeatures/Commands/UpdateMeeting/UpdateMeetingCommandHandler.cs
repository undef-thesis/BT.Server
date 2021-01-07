using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Application.Services.Image;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Commands.UpdateMeeting
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommand>
    {
        private readonly IImageService _imageService;
        private readonly IDataContext _dataContext;

        public UpdateMeetingCommandHandler(IImageService imageService, IDataContext dataContext)
        {
            _imageService = imageService;
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(UpdateMeetingCommand command, CancellationToken cancellationToken)
        {
            var meeting = await _dataContext.Meetings.SingleOrDefaultAsync(x => x.Id == command.Id &&
                x.MeetingOrganizerId == command.UserId);

            if (meeting is null)
            {
                throw new UserIsNotMeetingOrganizerException();
            }

            meeting.UpdateMeeting(command.Name, command.Description, command.MaxParticipants, command.Date, command.CategoryId);

            var address = await _dataContext.Address.SingleOrDefaultAsync(x => x.MeetingId == command.Id);

            double lat = Convert.ToDouble(command.Latitude, new CultureInfo("en-US"));
            double lng = Convert.ToDouble(command.Longitude, new CultureInfo("en-US"));
            address.UpdateAddress(lat, lng, command.Range, command.Country, command.Province,
                command.PostalCode, command.City, command.Street);

            var images = await _dataContext.MeetingImages.Where(x => x.MeetingId == command.Id).ToListAsync();
            var convertedImages = _imageService.ConvertImageToByte(command.Images);

            int i = 0;
            foreach (var image in images)
            {
                if (convertedImages.Count <= i)
                {
                    _dataContext.MeetingImages.Remove(image);
                }
                else
                {
                    image.UpdateImage(convertedImages[i].Item2, convertedImages[i].Item1);
                    _dataContext.MeetingImages.Update(image);
                }
                i++;
            }

            _dataContext.Meetings.Update(meeting);
            _dataContext.Address.Update(address);

            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}