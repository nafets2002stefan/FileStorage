using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileStorage.FileStorage.Resource.Service.Common;

namespace FileStorage.FileStorage.Resource.Service.Interfaces
{
    public interface ILocalFileService
    {
        ResultModel SaveFilePhysical(IFormFile file, string fileName, string path);
        ResultModel<MemoryStream> GetFileByFileName(string fileName, string path);
    }
}
