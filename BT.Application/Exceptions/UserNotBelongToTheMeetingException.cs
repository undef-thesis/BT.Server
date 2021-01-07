using System;

namespace BT.Application.Exceptions
{
    public class UserNotBelongToTheMeetingException : Exception
    {
        public UserNotBelongToTheMeetingException()
            : base("User not belong to the meeting")
        {

        }
    }
}