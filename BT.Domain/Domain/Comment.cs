using System;

namespace BT.Domain.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        protected Comment() {}

        public Comment(string content, Guid meetingId, Guid userId)
        {
            Id = Guid.NewGuid();
            Content = content;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            MeetingId = meetingId;
            UserId = userId;
        }
    }
}