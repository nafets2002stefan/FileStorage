using FileStorage.FileStorage.Resource.Contracts.FileStorage.Resource.Contracts.Queries;
using FileStorage.FileStorage.Resource.Contracts.FileStorage.Resource.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileStorage.FileStorage.Resource.Contracts
{
    public interface IFileStorageAccessor
    {
        //Modify later on to return a Result object or something like this
        void UploadFile(UploadFileCommand file);
         byte [] DownloadFile(DownloadFileQuery request);

    }
}
