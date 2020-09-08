
using Microsoft.AspNetCore.Mvc;

namespace BT.Application.DTO
{
    public class UserPofileDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] Avatar { get; set; }
        public FileContentResult AvatarFile { get; set; }
    }
}