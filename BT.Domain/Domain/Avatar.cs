using System;

namespace BT.Domain.Domain
{
    public class Avatar : Image
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        
        protected Avatar() {}

        public Avatar(string filename, byte[] picture, Guid userId)
            : base(filename: filename, picture: picture )
        {
            UserId = userId;
        }
    }
}