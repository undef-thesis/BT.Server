using System;
using BT.Domain.Domain;

namespace BT.Application.DTO
{
    public class MeetingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AddressDto Address { get; set; }
    }
}