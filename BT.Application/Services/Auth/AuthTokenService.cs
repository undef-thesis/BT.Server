using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BT.Application.DTO;
using Microsoft.IdentityModel.Tokens;

namespace BT.Application.Services.Auth
{
    public class AuthTokenService : IAuthTokenService
    {
        public AuthTokenService()
        {
            
        }

        public AuthDto CreateToken(Guid id)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = id.ToString(),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id.ToString()),
                    new Claim(ClaimTypes.Role, "user"),
                }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_sercret_key")),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = handler.CreateToken(tokenDescriptor);

            var token = new AuthDto
            {
                Token = handler.WriteToken(securityToken),
                Issuer = securityToken.Issuer,
                Subject = id,
                ValidFrom = securityToken.ValidFrom,
                ValidTo = securityToken.ValidTo
            };

            return token;
        }

        public bool Validate(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_sercret_key"));
            
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