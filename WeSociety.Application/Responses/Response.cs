using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.Responses
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Response(bool success)
        {
            Success = success;
            Message = string.Empty;
        }

        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }
    }
}
