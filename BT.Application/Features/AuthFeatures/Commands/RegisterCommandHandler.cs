using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Domain.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BT.Application.Services.Auth;
using System;

namespace BT.Application.Features.AuthFeatures.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IPasswordService _passwordService;
        private readonly IDataContext _dataContext;

        public RegisterCommandHandler(IDataContext dataContext, IPasswordService passwordService)
        {
            _dataContext = dataContext;
            _passwordService = passwordService;
        }

        public async Task<Unit> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var checkUser = await _dataContext.Users.SingleOrDefaultAsync(x => x.Email == command.Email);

            if(checkUser is object)
            {
                throw new Exception("User already exists");
            }

            if(command.Password != command.ConfirmPassword)
            {
                throw new Exception("Passwords are not equal");
            }

            var salt = _passwordService.CreateSalt();
            var password = _passwordService.HashPassword(command.Password, salt);

            var user = new User(command.Email, command.Firstname, command.Lastname, password, salt);

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            var newUser = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

            return Unit.Value;
        }
    }
}