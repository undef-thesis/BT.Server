using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.MeetingFeatures.Commands.AddMeetingImage
{
    public class AddMeetingImageCommandHandler : IRequestHandler<AddMeetingImageCommand>
    {
        private readonly IDataContext _dataContext;

        public AddMeetingImageCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(AddMeetingImageCommand command, CancellationToken cancellationToken)
        {
            var meeting = await _dataContext.Meetings.SingleOrDefaultAsync(
                x => x.Id == command.MeetingId && x.MeetingOrganizerId == command.UserId);

            if (meeting is null)
            {
                throw new UserIsNotMeetingOrganizerException();
            }

            var images = await _dataContext.MeetingImages.Where(x => x.MeetingId == command.MeetingId).ToListAsync();

            if (images.Count >= 3)
            {
                throw new System.Exception("Meeting can have max 3 images");
            }

            foreach (var image in command.Images)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }

                var meetingImage = new MeetingImage(image.FileName, imageData, command.MeetingId);

                await _dataContext.MeetingImages.AddAsync(meetingImage);
                await _dataContext.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}