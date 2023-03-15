using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Contracts.FileStorage.Resource.Contracts.Queries
{
    public class DownloadContentQuery
    {
        public string FileName { get; set; }

        public string Path { get; set; }

        public string GetSingleFilePath => $"{Path}/{FileName}";
    }
}
