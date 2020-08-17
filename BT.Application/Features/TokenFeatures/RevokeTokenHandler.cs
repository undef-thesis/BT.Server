using System;
using System.Threading;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Application.Exceptions;
using BT.Application.Services.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BT.Application.Features.TokenFeatures
{
    public class RevokeTokenHandler : IRequestHandler<RevokeTokenCommand>
    {
        private readonly IAuthTokenService _authTokensService;
        private readonly IAuthTokenCache _cache;
        private readonly IDataContext _dataContext;
        private readonly ILogger<RevokeTokenHandler> _logger;

        public RevokeTokenHandler(IAuthTokenService authTokensService, IAuthTokenCache cache,
            IDataContext dataContext, ILogger<RevokeTokenHandler> logger)
        {
            _authTokensService = authTokensService;
            _cache = cache;
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(RevokeTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.Include(x => x.RefreshToken).SingleOrDefaultAsync(x => x.RefreshToken.Token == command.RefreshToken);
            
            if (user is null)
            {
                throw new UserNotFoundException("or token");
            }

            var refreshToken = user.RefreshToken;

            if (!refreshToken.IsActive)
            {
                throw new TokenException("Refresh token is expired or inactive");
            }

            refreshToken.SetRevokedDate(DateTime.UtcNow);

            _dataContext.RefreshToken.Update(refreshToken);
            await _dataContext.SaveChangesAsync();

            return await Unit.Task;
        }
    }
}