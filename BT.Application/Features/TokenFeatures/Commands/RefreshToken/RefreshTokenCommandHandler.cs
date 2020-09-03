using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.DTO;
using BT.Application.Exceptions;
using BT.Application.Services.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BT.Application.Features.TokenFeatures.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthDto>
    {
        private readonly IAuthTokenService _authTokensService;
        private readonly IAuthTokenCache _cache;
        private readonly IDataContext _dataContext;
        private readonly ILogger<RefreshTokenCommandHandler> _logger;

        public RefreshTokenCommandHandler(IAuthTokenService authTokensService, IAuthTokenCache cache, 
            IDataContext dataContext, ILogger<RefreshTokenCommandHandler> logger)
        {
            _authTokensService = authTokensService;
            _cache = cache;
            _dataContext = dataContext;
            _logger = logger;
        }
        
        public async Task<AuthDto> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.Include(x => x.RefreshToken).SingleOrDefaultAsync(x => x.RefreshToken.Token == command.RefreshToken);

            if (user is null)
            {
                throw new UserNotFoundException("or token");
            }

            var refreshToken = user.RefreshToken;

            if(!refreshToken.IsActive)
            {
                throw new TokenException("Refresh token is expired or inactive");
            }

            var token = _authTokensService.GenerateToken(user.Id, user.Email);

            var newRefreshToken = _authTokensService.GenerateRefreshToken(user.Id);
            token.RefreshToken = newRefreshToken.Token;

            await _dataContext.RefreshToken.AddAsync(newRefreshToken);
            await _dataContext.SaveChangesAsync();
            
            _cache.Set(token);

            return token;
        }
    }
}