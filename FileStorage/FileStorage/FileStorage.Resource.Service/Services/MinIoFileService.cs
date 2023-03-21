using FileStorage.FileStorage.Resource.Service.Common;
using FileStorage.FileStorage.Resource.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Minio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileStorage.FileStorage.Resource.Service.Services
{
    public class MinIoFileService: IMinIoService
    {
        private const int Mb = 1024 * 1024;
        private readonly MinioClient _minioClient;

        public MinIoFileService(IOptions<MinIo> configuration)
        {
            _minioClient = new MinioClient(configuration.Value.Endpoint, configuration.Value.AccessKey,
                configuration.Value.SecretKey);
        }

        public async Task<MemoryStream> DownloadFile(string bucketName, string fileName)
        {
            var memoryStream = new MemoryStream();
            try
            {
                await _minioClient.StatObjectAsync(bucketName, fileName);

                await _minioClient.GetObjectAsync(bucketName, fileName,
                    (stream) => { stream.CopyTo(memoryStream); });
                memoryStream.Position = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return memoryStream;
        }

        public async Task<ResultModel<bool>> UploadFileAsync(string bucketName, string fileName, byte[] file)
        {
            try
            {
                await CheckBucketIfExistsAndCreate(bucketName);

                using (var fileStream = new MemoryStream(file))
                {
                    await _minioClient.PutObjectAsync(bucketName, fileName, fileStream, fileStream.Length, "application/octet-stream");
                }
                var result = await _minioClient.StatObjectAsync(bucketName, fileName);
                return result != null ? new ResultModel<bool> { Result = true } : new ResultModel<bool> { Result = false }; 
            }
            catch (Exception exception)
            {
                return ResultHandler.Error<bool>(exception.Message);
            }
        }

        public async Task<ResultModel<bool>> UploadFileAsync(string bucketName, string fileName, IFormFile file)
        {
            try
            {
                await CheckBucketIfExistsAndCreate(bucketName);

                byte[] bs;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    bs = memoryStream.ToArray();
                }

                using (var fileStream = new MemoryStream(bs))
                {
                    await _minioClient.PutObjectAsync(bucketName, fileName, fileStream, fileStream.Length, file.ContentType);
                }

                var result = await _minioClient.StatObjectAsync(bucketName, fileName);
                return result != null ? new ResultModel<bool> { Result = true }: new ResultModel<bool> { Result = false }; 
            }
            catch (Exception exception)
            {
                return ResultHandler.Error<bool>(exception.Message);
            }
        }

        private async Task<ResultModel<bool>> CheckBucketIfExistsAndCreate(string bucketName)
        {
            try
            {
                var exists = await BucketExistsAsync(bucketName);
                return !exists.Result ? MakeBucketAsync(bucketName).Result : new ResultModel<bool> { Result = true };
            }
            catch (Exception exception)
            {
                return ResultHandler.Error<bool>(exception.Message);
            }

        }

        private async Task<ResultModel<bool>> BucketExistsAsync(string bucketName)
        {
            try
            {
                var found = await _minioClient.BucketExistsAsync(bucketName);
                return new ResultModel<bool> { Result = found };
            }
            catch (Exception exception) 
            {
                return ResultHandler.Error<bool>(exception.Message);
            }
        }
        public async Task<ResultModel<bool>> MakeBucketAsync(string bucketName)
        {
            try
            {
                await _minioClient.MakeBucketAsync(bucketName);
                return new ResultModel<bool> { Result = true };
            }
            catch (Exception exception)
            {
                return ResultHandler.Error<bool>(exception.Message);
            }
        }


    }
}
