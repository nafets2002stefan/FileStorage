using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileStorage.FileStorage.Resource.Service.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileStorage.FileStorage.Resource.Service.Interfaces
{
    public interface IMinIoService
    {
        //bucket is like a folder or directory
        Task<MemoryStream> DownloadFile(string bucketName, string fileName);

        Task<ResultModel<bool>> UploadFileAsync(string bucketName, string fileName, byte[] file);
        Task<ResultModel<bool>> UploadFileAsync(string bucketName, string fileName, IFormFile file);
    }
}
