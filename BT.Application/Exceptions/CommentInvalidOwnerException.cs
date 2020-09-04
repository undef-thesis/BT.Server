using System;

namespace BT.Application.Exceptions
{
    public class CommentInvalidOwnerException : Exception
    {
        public CommentInvalidOwnerException()
            : base("User is not comment owner")
        {

        }
    }
}