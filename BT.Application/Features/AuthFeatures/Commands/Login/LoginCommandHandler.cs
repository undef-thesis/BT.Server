using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using MediatR;
using BT.Application.Services.Auth;
using Microsoft.EntityFrameworkCore;
using BT.Application.Exceptions;
using BT.Application.DTO;

namespace BT.Application.Features.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler: IRequestHandler<LoginCommand, AuthDto>
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

        public async Task<AuthDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Email == command.Email);

            if(user is null)
            {
                throw new UserNotFoundException(command.Email);
            }

            var passwordHash = _passwordService.HashPassword(command.Password, user.Salt);

            if(passwordHash != user.Password)
            {
                throw new InvalidPasswordException();
            }

            var token = _authTokensService.GenerateToken(user.Id, user.Email);

            var refreshToken = _authTokensService.GenerateRefreshToken(user.Id);
            token.RefreshToken = refreshToken.Token;

            await _dataContext.RefreshToken.AddAsync(refreshToken);
            await _dataContext.SaveChangesAsync();

            _cache.Set(token);

            return token;
        }
    }
}