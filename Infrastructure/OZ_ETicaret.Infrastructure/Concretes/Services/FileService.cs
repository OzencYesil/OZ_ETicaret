using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using OZ_ETicaret.Application.Abstracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Infrastructure.Concretes.Services
{
    public class FileService(IHostEnvironment hostEnvironment) : IFileService
    {
        public async Task<Dictionary<string,string>> UploadFiles(IFormFileCollection files)
        {
            string path= Path.Combine(hostEnvironment.ContentRootPath,"wwwroot", "uploadedFiles");
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
           

            Dictionary<string,string> result = new Dictionary<string, string>();
            foreach (var file in files)
            {

                string newFileName = file.FileName.Replace(" ","_");
                string newFilePath = $"{Guid.NewGuid().ToString()}_{newFileName}";
                string filePath = Path.Combine(path, newFilePath);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);                
                result.Add(newFileName,  filePath);
            }

            return result;
        }
    }
}
