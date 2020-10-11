using System;
using System.Collections.Generic;

namespace BT.Domain.Domain
{
    public class Meeting
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ParticipantCount { get; protected set; }
        public int MaxParticipants { get; protected set; }
        public DateTime Date { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid MeetingOrganizerId { get; private set; }
        public User MeetingOrganizer { get; private set; }
        public Address Address { get; private set; }
        public ICollection<UserMeeting> Participants { get; private set; }
        public ICollection<Comment> Comments { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public ICollection<MeetingImage> Images { get; private set; }

        protected Meeting() {}

        public Meeting(string name, string description, int maxParticipants, DateTime date, Guid meetingOrganizerId, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            MaxParticipants = maxParticipants;
            Date = date;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            MeetingOrganizerId = meetingOrganizerId;
            CategoryId = categoryId;
        }

        public void UpdateMeeting(string name, string description, int maxParticipants, DateTime date)
        {
            Name = name;
            Description = description; 
            MaxParticipants = maxParticipants;
            Date = date;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddParticipantToCounter() 
        {
            ParticipantCount++;
        }
    }
}