using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Service.Common
{
    public static class ResultHandler
    {
        public static ResultModel NotValid(string message)
        {
            return new ResultModel
            {
                ExecStatus = Status.NotValid,
                Message = message
            };
        }
        public static ResultModel<T> NotValid<T>(string message) 
        {
            return new ResultModel<T>
            {
                ExecStatus = Status.NotValid,
                Message = message
            };
        }

        public static ResultModel NotFound(string message)
        {
            return new ResultModel
            {
                ExecStatus = Status.NotValid,
                Message = message
            };
        }

        public static ResultModel<T> NotFound<T>(string message)
        {
            return new ResultModel<T>
            {
                ExecStatus = Status.NotFound,
                Message = message
            };
        }

        public static ResultModel Error(string message)
        {
            return new ResultModel
            {
                ExecStatus = Status.Error,
                Message = message
            };
        }

        public static ResultModel<T> Error<T>(string message)
        {
            return new ResultModel<T>
            {
                ExecStatus = Status.Error,
                Message = message
            };
        }


        public static ResultModel<T> NotValidRequest<T>(ValidationResult validationResult)
        {
            return new ResultModel<T>
            {
                ExecStatus = Status.NotValid,
                ValidationResult = validationResult
            };
        }

        public static ResultModel NotValidRequest(ValidationResult validationResult)
        {
            return new ResultModel
            {
                ExecStatus = Status.NotValid,
                ValidationResult = validationResult
            };
        }

    }
}
