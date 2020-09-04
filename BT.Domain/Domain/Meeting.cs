using System;
using System.Collections.Generic;

namespace BT.Domain.Domain
{
    public class Meeting
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid MeetingOrganizerId { get; set; }
        public User MeetingOrganizer { get; set; }
        public Address Address { get; private set; }
        public ICollection<UserMeeting> Partcipants { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        protected Meeting() {}

        public Meeting(string name, string description, Guid meetingOrganizerId, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            MeetingOrganizerId = meetingOrganizerId;
            CategoryId = categoryId;
        }
    }
}