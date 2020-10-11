using System;

namespace BT.Application.Exceptions
{
    public class MeetingHasNotFreeSlotsException : Exception
    {
        public MeetingHasNotFreeSlotsException()
            : base("Meeting has not free slots")
        {

        }
    }
}