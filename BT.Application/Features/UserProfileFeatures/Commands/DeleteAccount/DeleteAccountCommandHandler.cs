using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.UserProfileFeatures.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IDataContext _dataContext;

        public DeleteAccountCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == command.UserId);

            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}