using System;

namespace BT.Domain.Domain
{
    public class UserMeeting
    {
        protected UserMeeting() {}
        public UserMeeting(Guid userId, User user, Guid meetingId, Meeting meeting)
        {
            this.UserId = userId;
            this.User = user;
            this.MeetingId = meetingId;
            this.Meeting = meeting;

        }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}