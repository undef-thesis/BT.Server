using System;
using BT.Application.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace BT.Application.Services.Auth
{
    public class AuthTokenCache : IAuthTokenCache
    {
        private readonly IMemoryCache _cache;

        public AuthTokenCache(IMemoryCache cache)
            => _cache = cache;

        public void Set(AuthDto dto)
            => _cache.Set(dto.Subject, dto, TimeSpan.FromSeconds(30));

        public AuthDto Get(string email)
            => _cache.Get<AuthDto>(email);
    }
}