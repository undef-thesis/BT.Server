using System;

namespace BT.Application.Exceptions
{
    public class UserAlreadyBelongsToTheMeetingException : Exception
    {
        public UserAlreadyBelongsToTheMeetingException()
            :base("User already belongs to the meeting")
        {
            
        }
    }
}