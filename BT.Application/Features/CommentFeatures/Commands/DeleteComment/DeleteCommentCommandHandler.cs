using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.CommentFeatures.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IDataContext _dataContext;

        public DeleteCommentCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            var comment = await _dataContext.Comments.SingleOrDefaultAsync(x => x.Id == command.Id);

            if (comment is null)
            {
                throw new CommentNotFoundException();
            }

            if(comment.UserId != command.UserId)
            {
                throw new CommentInvalidOwnerException();
            }

            _dataContext.Comments.Remove(comment);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}