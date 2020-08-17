using System;

namespace BT.Domain.Domain
{
    public class RefreshToken
    {
        public Guid Id { get; private set; }
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; private set; }
        public DateTime? Revoked { get; private set; }
        public bool IsActive => Revoked == null && !IsExpired;
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        protected RefreshToken() {}

        public RefreshToken(string token, DateTime expires, Guid userId)
        {
            Id = Guid.NewGuid();
            Token = token;
            Expires = expires;
            Created = DateTime.UtcNow;

            UserId = userId;
        }

        public void SetRevokedDate(DateTime revoked)
        {
            Revoked = revoked;
        }
    }
}