using System;

namespace BT.Application.Exceptions
{
    public class TokenException : Exception
    {
        public TokenException(string message)
            :base($"{message}")
        {
            
        }
    }
}