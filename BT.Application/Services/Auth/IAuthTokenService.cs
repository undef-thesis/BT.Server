using System;
using BT.Application.DTO;
using BT.Domain.Domain;

namespace BT.Application.Services.Auth
{
    public interface IAuthTokenService
    {
        AuthDto GenerateToken(Guid userId, string email);
        RefreshToken GenerateRefreshToken(Guid userId);
        AuthDto RefreshToken(Guid id);
        bool RevokeToken();
        bool Validate(string token);
    }
}