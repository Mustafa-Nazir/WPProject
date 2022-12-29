using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);

        }

        public bool IsFileEmpty(IFormFile file)
        {
            if (file.Length <= 0) return true;
            return false;
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath)) Delete(filePath);
            return Upload(file,root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (IsFileEmpty(file)) return null;
            if (!Directory.Exists(root)) Directory.CreateDirectory(root);

            string extension = Path.GetExtension(file.FileName);
            string guid = Guid.NewGuid().ToString();
            string filePath = guid + extension;

            using (FileStream fileStream = File.Create(root+filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return filePath;
            }
        }
    }
}
