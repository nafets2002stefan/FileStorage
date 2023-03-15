using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Contracts.FileStorage.Resource.Contracts.Commands
{
    public class UploadFileCommand
    {
        public string Stream { get; set; }
        public string CustomPath { get; set; }
        public string ContentType { get; set; }

        public string Extension { get; set; }

        public string FileName { get; set; }
    }
}