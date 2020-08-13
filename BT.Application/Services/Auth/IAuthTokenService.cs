using System;
using BT.Application.DTO;

namespace BT.Application.Services.Auth
{
    public interface IAuthTokenService
    {
        AuthDto CreateToken(Guid id);
        bool Validate(string token);
    }
}