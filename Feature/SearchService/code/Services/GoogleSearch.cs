using System;
using System.Net.Http;
using System.Threading.Tasks;
using SearchFight.Foundation.ClientService.Abstractions;
using Newtonsoft.Json;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Configs;
using SearchFight.Feature.SearchService.Models.Google;
using SearchFight.Foundation.Utilities.Extensions;

namespace SearchFight.Feature.SearchService.Services
{
    public class GoogleSearch : ISearchEngine
    {
        private readonly IClientService _clientService;

        public GoogleSearch(IClientService clientService)
        {
            _clientService = clientService;
        }

        public string SearchEngine => "Google";

        public async Task<long> GetTotalResults(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                throw new ArgumentException("Query can't be null or empty.", nameof(term));
            }

            var uri = new Uri(GoogleConfig.Current.ApiUrl)
                .AddParameter("key", GoogleConfig.Current.ApiKey)
                .AddParameter("cx", GoogleConfig.Current.ContextId)
                .AddParameter("q", term);

            var results = await _clientService.Execute(uri, HttpMethod.Get);

            if (!results.IsSuccessStatusCode)
            {
                throw new Exception($"{results.ResponseStatusCode} was thrown");
            }

            var response = JsonConvert.DeserializeObject<GoogleResponse>(results.ResponseBody);

            return long.Parse(response.SearchInformation.TotalResults);
        }
    }
}
