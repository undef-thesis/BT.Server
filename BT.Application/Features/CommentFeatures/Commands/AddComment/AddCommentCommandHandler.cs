using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.CommentFeatures.Commands.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
    {
        private readonly IDataContext _dataContext;

        public AddCommentCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(AddCommentCommand command, CancellationToken cancellationToken)
        {
            var meeting = await _dataContext.Meetings.SingleOrDefaultAsync(x => x.Id == command.MeetingId);

            if(meeting is null)
            {
                throw new MeetingNotFoundException();
            }

            var comment = new Comment(command.Content, meeting.Id, command.UserId);

            await _dataContext.Comments.AddAsync(comment);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}