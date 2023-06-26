using System.Net;
using System.Text.Json;

namespace Devsu.Core.Models
{
    public class Result
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; } = string.Empty;

        public Result()
        {
            Code = HttpStatusCode.OK;
        }

        public Result(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
