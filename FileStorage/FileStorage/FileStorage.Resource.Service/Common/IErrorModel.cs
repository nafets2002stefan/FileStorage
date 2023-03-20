using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Service.Common
{
    public interface IErrorModel
    {
        string Key { get; set; }
        string Message { get; set; }
        string ToString();

    }
}
