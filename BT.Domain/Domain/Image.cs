using System;

namespace BT.Domain.Domain
{
    public abstract class Image
    {
        public Guid Id { get; protected set; }
        public string Filename { get; protected set; }
        public byte[] Picture { get; protected set; }

        protected Image() {}

        public Image(string filename, byte[] picture)
        {
            Id = Guid.NewGuid();
            Filename = filename;
            Picture = picture;
        }
    }
}