using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_ETicaret.Application.Abstracts.Services
{
    public interface IFileService
    {
        Task<Dictionary<string,string>> UploadFiles(IFormFileCollection files);
    }
}
