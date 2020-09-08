using System;
using System.Collections.Generic;

namespace BT.Domain.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Password { get; private set; }
        public byte[] Salt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public RefreshToken RefreshToken { get; private set; }
        public ICollection<Meeting> OrganizedMeetings { get; private set; }
        public ICollection<UserMeeting> EnrolledMeetings { get; private set; }
        public ICollection<Comment> Comments { get; private set; }
        public Avatar Avatar { get; set; }

        protected User() {}
        
        public User(string email, string firstName, string lastName, string password, byte[] salt)
        {
            Id = Guid.NewGuid();
            Email = email;
            Firstname = firstName;
            Lastname = lastName;
            Password = password;
            Salt = salt;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}