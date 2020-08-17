using System;

namespace BT.Application.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("Provided invalid password")
        {
            
        }
    }
}