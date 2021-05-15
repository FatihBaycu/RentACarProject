using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelperAsync
    {
        public static async Task<string> ImageSave(IFormFile imageFile)
        {
            var getExtensions = Path.GetExtension(imageFile.FileName).ToLower();

            var imageName = DateTime.Now.ToString("yymmssfff") + Guid.NewGuid() + getExtensions;
            var imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + PathNames.AddCarImage, imageName);

            using var fileStream = new FileStream(imagePath, FileMode.Create);

            await imageFile.CopyToAsync(fileStream);

            return PathNames.CarImage + imageName;
        }
    }
}