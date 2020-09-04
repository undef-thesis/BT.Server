using System;

namespace BT.Application.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException()
            : base("Category was not found")
        {
            
        }
    }
}