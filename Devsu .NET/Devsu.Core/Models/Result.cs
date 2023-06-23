using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Devsu.Core.Models
{
    public class Result
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;

        public object? Data { get; set; }

        public Result()
        {
            Code = StatusCodes.Status200OK;
        }

        public Result(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public Result(int code, object? data)
        {
            Code = code;
            Data = data;
        }

        public Result(int code, string message, object? data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
