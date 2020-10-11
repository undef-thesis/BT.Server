using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BT.Application.Services.Image
{
    public class ImageService : IImageService
    {
        public IList<(byte[], string)> ConvertImageToByte(IEnumerable<IFormFile> images)
        {
            var convertedImages = new List<(byte[], string)>();

            foreach (var image in images)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                    imageData = ResizeImage(imageData);

                    convertedImages.Add((imageData, image.FileName));
                }
            }

            return convertedImages;
        }

        private byte[] ResizeImage(byte[] image)
        {
            using (MemoryStream inStream = new MemoryStream(image))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (SixLabors.ImageSharp.Image imageSharp = SixLabors.ImageSharp.Image.Load(inStream))
                    {
                        var ratioX = (double)500 / imageSharp.Width;
                        var ratioY = (double)500 / imageSharp.Height;
                        var ratio = Math.Min(ratioX, ratioY);

                        var width = (int)(imageSharp.Width * ratio);
                        var height = (int)(imageSharp.Height * ratio);

                        imageSharp.Mutate(x => x.Resize(width, height));
                        imageSharp.SaveAsJpeg(outStream);
                        imageSharp.Dispose();
                    }

                    image = outStream.ToArray();
                    outStream.Flush();
                    inStream.Flush();
                }
            }

            return image;
        }
    }
}