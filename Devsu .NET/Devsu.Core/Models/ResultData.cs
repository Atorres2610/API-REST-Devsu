using System.Net;

namespace Devsu.Core.Models
{
    public class ResultData : Result
    {
        public ResultData(HttpStatusCode code, string message, object? data) : base(code, message)
        {
            Data = data;
        }

        public object? Data { get; set; }
    }
}
