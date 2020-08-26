using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SearchFight.Foundation.ClientService.Abstractions;
using SearchFight.Foundation.ClientService.Models;

namespace SearchFight.Foundation.ClientService.Services
{
    public class ApiClientService : IClientService
    {
        private readonly ILogger _loggerFactory;

        public ApiClientService(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory.CreateLogger<ApiClientService>();
        }

        public async Task<Result> Execute(Uri uri, HttpMethod method, HttpContent payload = null, string headerType = null, string headerTypeValue = null)
        {
            var httpClientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = method,
                RequestUri = uri
            };

            httpRequestMessage.Headers.Add("Cache-Control", "no-cache");

            if (!string.IsNullOrEmpty(headerType) && !string.IsNullOrEmpty(headerTypeValue))
            {
                httpRequestMessage.Headers.Add(headerType, headerTypeValue);
            }

            return await Execute(httpClientHandler, httpRequestMessage, payload);
        }

        public async Task<Result> Execute(HttpClientHandler httpClientHandler, HttpRequestMessage httpRequestMessage, HttpContent payload = null)
        {
            try
            {
                using var client = new HttpClient(httpClientHandler);
                
                if (payload != null)
                {
                    httpRequestMessage.Content = payload;
                }

                var response = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);

                return response.IsSuccessStatusCode
                    ? new Result(response.IsSuccessStatusCode, response.StatusCode, await response.Content.ReadAsStringAsync().ConfigureAwait(false))
                    : new Result(response.IsSuccessStatusCode, response.StatusCode);
            }
            catch (Exception ex)
            {
                _loggerFactory.LogError($"There has been a problem making the request to the API.{ex.Message}");

                return new Result(ex);
            }
        }
    }
}
