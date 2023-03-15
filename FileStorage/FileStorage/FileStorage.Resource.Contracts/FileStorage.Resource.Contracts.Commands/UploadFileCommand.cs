using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Contracts.FileStorage.Resource.Contracts.Commands
{
    public enum FileExtension {
        Pdf,
        Excel,
        Doc,
        Jpg,
        Jpeg
    }

    public class UploadFileCommand
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public string FilePath { get; set; }
        public FileExtension FileType { get; set; }
    }

}