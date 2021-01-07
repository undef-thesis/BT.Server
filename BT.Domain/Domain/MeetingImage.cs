using System;

namespace BT.Domain.Domain
{
    public class MeetingImage : Image
    {
        public Guid MeetingId { get; private set; }
        public Meeting Meeting { get; private set; }

        protected MeetingImage() { }

        public MeetingImage(string filename, byte[] picture, Guid meetingId)
            : base(filename: filename, picture: picture)
        {
            MeetingId = meetingId;
        }

        public void UpdateImage(string filename, byte[] picture)
        {
            Filename = filename;
            Picture = picture;
        }
    }
}