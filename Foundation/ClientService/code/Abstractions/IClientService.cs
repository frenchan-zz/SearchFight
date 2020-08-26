using System;
using System.Net.Http;
using System.Threading.Tasks;
using SearchFight.Foundation.ClientService.Models;

namespace SearchFight.Foundation.ClientService.Abstractions
{
    public interface IClientService
    {
        Task<Result> Execute(Uri uri, HttpMethod method, HttpContent payload = null, string headerType = null, string headerTypeValue = null);
        Task<Result> Execute(HttpClientHandler httpClientHandler, HttpRequestMessage httpRequestMessage, HttpContent payload = null);
    }
}
