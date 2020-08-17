using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BT.Application.DTO;
using BT.Application.Options;
using BT.Domain.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BT.Application.Services.Auth
{
    public class AuthTokenService : IAuthTokenService
    {
        private readonly IdentityOptions _options;
        public AuthTokenService(IOptions<IdentityOptions> options)
            => _options = options.Value;

        public AuthDto GenerateToken(Guid userId, string email)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = userId.ToString(),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, "user"),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_options.TokenValidInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = handler.CreateToken(tokenDescriptor);

            var token = new AuthDto
            {
                Token = handler.WriteToken(securityToken),
                Issuer = securityToken.Issuer,
                Subject = email,
                ValidFrom = securityToken.ValidFrom,
                ValidTo = securityToken.ValidTo
            };

            return token;
        }

        public RefreshToken GenerateRefreshToken(Guid userId)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);

                var token = Convert.ToBase64String(randomBytes);
                var expires = DateTime.UtcNow.AddDays(_options.RefreshTokenValidInDays);

                var refreshToken = new RefreshToken(token, expires, userId);
                
                return refreshToken;
            }
        }

        public AuthDto RefreshToken(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RevokeToken()
        {
            throw new NotImplementedException();
        }

        public bool Validate(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            try
            {
                var jwt = handler.ReadToken(token);

                handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = jwt.Issuer,
                    IssuerSigningKey = signingKey
                }, out _);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}