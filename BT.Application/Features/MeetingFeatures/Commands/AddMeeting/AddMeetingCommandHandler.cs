using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Application.Services.Image;
using BT.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BT.Application.Features.MeetingFeatures.Commands.AddMeeting
{
    public class AddMeetingCommandHandler : IRequestHandler<AddMeetingCommand>
    {
        private readonly IImageService _imageService;
        private readonly IDataContext _dataContext;

        public AddMeetingCommandHandler(IImageService imageService, IDataContext dataContext)
        {
            _imageService = imageService;
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(AddMeetingCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == command.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Id == command.CategoryId);

            if (category is null)
            {
                throw new CategoryNotFoundException();
            }

            var meeting = new Meeting(command.Name, command.Description, command.MaxParticipants,
                command.Date, user.Id, category.Id);
            meeting.AddParticipantToCounter();

            double lat = Convert.ToDouble(command.Latitude, new CultureInfo("en-US"));
            double lng = Convert.ToDouble(command.Longitude, new CultureInfo("en-US"));

            var address = new Address(lat, lng, command.Range, command.Country,
                command.Province, command.PostalCode, command.City, command.Street, meeting.Id);

            var userMeeting = new UserMeeting(user.Id, user, meeting.Id, meeting);

            await _dataContext.Meetings.AddAsync(meeting);
            await _dataContext.Address.AddAsync(address);
            await _dataContext.UserMeeting.AddAsync(userMeeting);

            var convertedImages = _imageService.ConvertImageToByte(command.Images);

            foreach (var image in convertedImages)
            {
                var meetingImage = new MeetingImage(image.Item2, image.Item1, meeting.Id);
                await _dataContext.MeetingImages.AddAsync(meetingImage);
            }

            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}