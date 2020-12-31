using System;
using System.Collections.Generic;

namespace BT.Application.DTO
{
    public class MeetingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParticipantCount { get; set; }
        public int MaxParticipants { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CategoryDto Category { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<MeetingImageDto> Images { get; set; }
    }
}