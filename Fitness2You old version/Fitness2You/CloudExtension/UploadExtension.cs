using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness2You.CloudExtension
{
    public class UploadExtension
    {
        public static async Task<List<string>> UploadAsync(Cloudinary cloundinary, ICollection<IFormFile> files)
        {
            List<string> urlImage = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, destinationStream)
                    };

                    var result = await cloundinary.UploadAsync(uploadParams);
                    urlImage.Add(result.Uri.AbsoluteUri);
                }
            }

            return urlImage;
        }
    }
}
