using System;

namespace BT.Application.DTO
{
    public class AuthDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Issuer { get; set; }
        public Guid Subject { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}