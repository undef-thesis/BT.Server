using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.UserProfileFeatures.Commands.AddAvatar
{
    public class AddAvatarCommandHandler : IRequestHandler<AddAvatarCommand>
    {
        private readonly IDataContext _dataContext;

        public AddAvatarCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(AddAvatarCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == command.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }
            
            var avatar = await _dataContext.Avatar.SingleOrDefaultAsync(x => x.UserId == command.UserId);

            if(avatar != null)
            {
                throw new System.Exception("User can not have 2 avatars");
            }

            byte[] imageData = null;    
            using (var binaryReader = new BinaryReader(command.Avatar.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)command.Avatar.Length);
            }

            avatar = new Avatar(command.Avatar.FileName, imageData, command.UserId);

            await _dataContext.Avatar.AddAsync(avatar);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}