using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Application.Services.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.UserProfileFeatures.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IPasswordService _passwordService;
        private readonly IDataContext _dataContext;

        public ChangePasswordCommandHandler(IPasswordService passwordService, IDataContext dataContext)
        {
            _passwordService = passwordService;
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == command.UserId);
            var passwordHash = _passwordService.HashPassword(command.Password, user.Salt);

            if (passwordHash != user.Password)
            {
                throw new InvalidPasswordException();
            }

            if (command.NewPassword == command.ConfirmNewPassword)
            {
                var newPasswordHash = _passwordService.HashPassword(command.NewPassword, user.Salt);
                user.SetPassword(newPasswordHash);

                _dataContext.Users.Update(user);
                await _dataContext.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}