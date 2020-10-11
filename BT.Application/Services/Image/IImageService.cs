using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BT.Application.Services.Image
{
    public interface IImageService
    {
        IList<(byte[], string)> ConvertImageToByte(IEnumerable<IFormFile> images);
    }
}