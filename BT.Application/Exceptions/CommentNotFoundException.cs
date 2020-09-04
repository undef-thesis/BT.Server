using System;

namespace BT.Application.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException()
            : base("Comment not found")
        {

        }
    }
}