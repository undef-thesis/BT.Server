using System;

namespace BT.Domain.Domain
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid MeetingId { get; private set; }
        public Meeting Meeting { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

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

        public void UpdateComment(string content)
        {
            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}