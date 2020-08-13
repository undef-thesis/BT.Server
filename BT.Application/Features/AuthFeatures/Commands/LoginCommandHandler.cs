using System;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using MediatR;
using BT.Application.Services.Auth;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Features.AuthFeatures.Commands
{
    public class LoginCommandHandler: IRequestHandler<LoginCommand>
    {
        private readonly IAuthTokenService _authTokensService;
        private readonly IPasswordService _passwordService;
        private readonly IAuthTokenCache _cache;        
        private readonly IDataContext _dataContext;

        public LoginCommandHandler(IAuthTokenService authTokensService, IPasswordService passwordService, 
            IAuthTokenCache cache, IDataContext dataContext)
        {
            _authTokensService = authTokensService;
            _passwordService = passwordService;
            _cache = cache;
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Email == command.Email);

            if(user is null)
            {
                throw new Exception("User is not exists");
            }

            var passwordHash = _passwordService.HashPassword(command.Password, user.Salt);

            if(passwordHash != user.Password)
            {
                throw new Exception("Wrong password");
            }

            var token = _authTokensService.CreateToken(user.Id);
            token.Subject = command.TokenId;

            _cache.Set(token);

            return Unit.Value;
        }
    }
}