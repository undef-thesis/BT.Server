using System;

namespace BT.Application.Exceptions
{
    public class MeetingNotFoundException : Exception
    {
        public MeetingNotFoundException()
            : base("Meeting not found")
        {

        }
    }
}