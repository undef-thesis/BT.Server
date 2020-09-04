using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.CommentFeatures.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IDataContext _dataContext;

        public UpdateCommentCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
        {
            var comment = await _dataContext.Comments.SingleOrDefaultAsync(x => x.Id == command.Id);

            if (comment is null)
            {
                throw new CommentNotFoundException();
            }

            if (comment.UserId != command.UserId)
            {
                throw new CommentInvalidOwnerException();
            }

            comment.Content = command.Content;

            _dataContext.Comments.Update(comment);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}