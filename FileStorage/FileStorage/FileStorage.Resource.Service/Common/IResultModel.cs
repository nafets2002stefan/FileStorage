using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Service.Common
{
    public interface IResultModel<T>
    {
        Status ExecStatus { get; set; }

        ICollection<IErrorModel> Errors { get; set; }

        T Result { get; set; }

        Guid? KeyEntity { get; set; }
    }
}
