using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {

        public static string DefaultImagePath = Directory.GetCurrentDirectory() + @"\CarImages\defaultImage.jpg";
        public static string UploadImagePath = Directory.GetCurrentDirectory() + @"\CarImages";


        public static string CreatePath(IFormFile file)
        {

            FileInfo fileInfo = new FileInfo(file.FileName);

            string path = Path.Combine(UploadImagePath);
            string fileExtension = fileInfo.Extension;
            string uniqueFilename = Guid.NewGuid().ToString() + fileExtension;
            string result = $@"{path}\{uniqueFilename}";

            return result;

        }


        public static string AddFile(IFormFile file)
        {

            string result;

            try
            {
                if (file == null)
                {
                    result = DefaultImagePath;

                    return result;
                }
                else
                {
                    result = CreatePath(file);

                    var sourcePath = Path.GetTempFileName();

                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    File.Move(sourcePath, result);

                    return result;
                }
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }


        public static string DeleteFile(string imagePath)
        {

            try
            {
                File.Delete(imagePath);

                return "Deleted";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }


        public static string UpdateFile(IFormFile file, string oldImagePath)
        {

            string result;

            try
            {
                if (file == null)
                {
                    File.Delete(oldImagePath);

                    result = DefaultImagePath;

                    return result;
                }
                else
                {
                    result = CreatePath(file);

                    var sourcePath = Path.GetTempFileName();

                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    File.Move(sourcePath, result);

                    File.Delete(oldImagePath);

                    return result;
                }
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }


    }
}

