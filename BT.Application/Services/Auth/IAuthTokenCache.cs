using System;
using BT.Application.DTO;

namespace BT.Application.Services.Auth
{
    public interface IAuthTokenCache
    {
        void Set(AuthDto dto);
        AuthDto Get(Guid userId); 
    }
}