using System;

namespace BT.Application.DTO
{
    public class UserPofileDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] Avatar { get; set; }
    }
}