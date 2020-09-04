using System;
using System.Collections.Generic;

namespace BT.Domain.Domain
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public ICollection<Meeting> Meetings { get; private set; }

        protected Category() { }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateCategory(string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}