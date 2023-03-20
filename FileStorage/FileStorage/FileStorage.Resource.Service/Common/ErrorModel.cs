using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FileStorage.FileStorage.Resource.Service.Common
{
    public sealed class ErrorModel : IErrorModel
    {
        private const string ToStringFormat = "{0}: {1}";

        public ErrorModel() { }

        public ErrorModel(string key, string message = null) 
        {
            Key = key;

            if(!string.IsNullOrEmpty(message)) 
                Message = message.Trim();
        }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public override string ToString() =>
            string.Format(ToStringFormat, Key, Message);

        public static implicit operator ErrorModel(string formatted)
        {
            try
            {
                string[] parts = formatted.Split(':');
                if(parts.Length < 2 )
                    return new ErrorModel(ExceptionCodes.UnhandledException, formatted);
                
                if(parts.Length == 2) 
                    return new ErrorModel(parts[0], parts[1]);

                return new ErrorModel(parts[0], formatted.Substring(parts[0].Length).TrimStart(':').Trim());
            }
            catch (Exception)
            {
                return new ErrorModel(ExceptionCodes.UnhandledException, formatted);
            }

        }
    }
}
