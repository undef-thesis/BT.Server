using System;

namespace BT.Application.Exceptions
{
    public class UserIsNotMeetingOrganizerException : Exception
    {
        public UserIsNotMeetingOrganizerException() 
            : base("User is not a meeting organizer")
        {

        }
    }
}