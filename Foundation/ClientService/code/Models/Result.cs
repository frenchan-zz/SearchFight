using System;
using System.Net;
using SearchFight.Foundation.ClientService.Abstractions;

namespace SearchFight.Foundation.ClientService.Models
{
    public class Result : IClientResult
    {
        public bool IsSuccessStatusCode { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }
        public string ResponseBody { get; set; }

        internal Result(bool isSuccessStatusCode, HttpStatusCode responseStatusCode, string responseBody = null)
        {
            IsSuccessStatusCode = isSuccessStatusCode;
            ResponseStatusCode = responseStatusCode;
            ResponseBody = responseBody;
        }

        internal Result(Exception exception)
        {
            IsSuccessStatusCode = false;
            ResponseStatusCode = HttpStatusCode.InternalServerError;
            ResponseBody = exception.Message;
        }
    }
}
