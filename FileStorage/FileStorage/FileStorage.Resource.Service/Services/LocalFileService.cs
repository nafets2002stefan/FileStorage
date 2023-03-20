using FileStorage.FileStorage.Resource.Service.Common;
using FileStorage.FileStorage.Resource.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Service.Services
{
    public class LocalFileService : ILocalFileService
    {
        public ResultModel SaveFilePhysical(IFormFile file, string fileName, string path)
        {
            if(file.Length <= 0) return ResultHandler.NotValid("File is null or empty");

            try
            {
                var directory = Path.Combine(path);
                var exists = Directory.Exists(directory);
                if(!exists) Directory.CreateDirectory(directory);
                var filePath = Path.Combine(directory, fileName);
                var fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);

                return new ResultModel { ExecStatus = Status.Success };
            }
            catch (Exception exception) 
            {
                return ResultHandler.Error(exception.Message);
            }
        }

        public ResultModel<MemoryStream> GetFileByFileName(string fileName, string path)
        {
            try
            {
                var directory = Path.Combine(path);
                var filePath = Path.Combine(directory, fileName);
                if (!System.IO.File.Exists(filePath)) return ResultHandler.NotFound<MemoryStream>("File not found");
                var fileStream = new FileStream(filePath, FileMode.Open);

                var memoryStream = new MemoryStream();
                fileStream.CopyTo(memoryStream);
                return new ResultModel<MemoryStream>
                {
                    ExecStatus = Status.Success,
                    Result = memoryStream
                };
            }
            catch (Exception e)
            {
                return ResultHandler.Error<MemoryStream>(e.Message);
            }
        }

    }
}
