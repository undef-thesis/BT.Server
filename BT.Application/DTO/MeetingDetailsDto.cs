using System;
using System.Collections.Generic;

namespace BT.Application.DTO
{
    public class MeetingDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}