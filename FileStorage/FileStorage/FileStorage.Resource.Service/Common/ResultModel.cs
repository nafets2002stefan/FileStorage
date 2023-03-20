using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Service.Common
{
    public class ResultModel : ResultModel<object>
    {
    }

    public enum Status
    {
        Success,
        Error,
        NotValid,
        NotFound,
        AccessDenied
    }

    public class ResultModel<T>: IResultModel<T>
    {
        [JsonProperty("execStatus")]
        public Status ExecStatus { get; set; } = Status.Success;

        [JsonProperty("errors")]
        public virtual ICollection<IErrorModel> Errors { get; set; } = new List<IErrorModel>();

        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("attributes")]
        public string Attributes { get; set; }

        [JsonProperty("keyEntitty")]
        public Guid? KeyEntity { get; set; }

        [JsonProperty("validationResult")]
        public ValidationResult ValidationResult { get; set; }

        public ResultModel ToBase() => new ResultModel
        {
            ExecStatus = ExecStatus,
            Result = Result,
            Errors = Errors,
            KeyEntity = KeyEntity
        };

        public virtual ResultModel<TModelOutput> Map<TModelOutput>(TModelOutput result = default) => new ResultModel<TModelOutput>
        {
            ExecStatus = ExecStatus,
            Result = result,
            Errors = Errors,
            ValidationResult = ValidationResult
        };
    }
}
