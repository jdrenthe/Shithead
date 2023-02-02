using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Shithead.Shared.Models;

namespace Shithead.Shared.Services
{
    public class ImageInputServices : IImageInputServices
    {
        /// <summary>
        /// Reads the given file to write it in memory so that it can be converted to base64
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Image</returns>
        public async Task<Image> CompressToBase64(InputFileChangeEventArgs args)
        {
            Image image = new();
            var file = args.File;

            // Checks if file is not null
            if (file == null || file.Name == null || file.ContentType == null)
            {
                image.Error = "Select an image.";
                return image;
            }

            // Fills image imput text
            image.Name = !string.IsNullOrEmpty(file.Name) ? file.Name : "Select an image.";
            if (string.IsNullOrEmpty(file.Name))
            {
                image.Error = "Select an image.";
                return image;
            }

            // Checks if uploaded image is greater than 5 MB
            if ((file.Size / 1024f) / 1024f > 5 || file.Size < 0)
            {
                image.Error = "Image can't be greater than 5 MB.";
                return image;
            }

            var validFileTyps = new string[] { "image/png", "image/jpg", "image/jpeg", "image/gif" };
            if (!validFileTyps.Any(vft => vft == file.ContentType))
            {
                image.Error = "Png, jpg, jpeg and gif are the only allowed image types.";
                return image;
            }

            try
            {
                // defines streamreader via file data
                using (var sr = new System.IO.StreamReader(file.OpenReadStream()))
                {
                    // defines memorystream to write to
                    var bytes = default(byte[]);
                    using (var ms = new System.IO.MemoryStream())
                    {
                        await sr.BaseStream.CopyToAsync(ms);
                        bytes = ms.ToArray();
                    }

                    image.Base64 = $"data:{file.ContentType};base64,{Convert.ToBase64String(bytes)}";
                    image.Error = null;

                    return image;
                }
            }
            catch
            {
                image.Error = "There went something wrong with image upload.";
                return image;
            }
        }
    }
}
