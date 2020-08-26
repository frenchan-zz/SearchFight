using System;
using System.Net.Http;
using System.Threading.Tasks;
using SearchFight.Foundation.ClientService.Abstractions;
using Newtonsoft.Json;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Configs;
using SearchFight.Feature.SearchService.Models.Bing;
using SearchFight.Foundation.Utilities.Extensions;

namespace SearchFight.Feature.SearchService.Services
{
    public class BingSearch : ISearchEngine
    {
        private readonly IClientService _clientService;

        public BingSearch(IClientService clientService)
        {
            _clientService = clientService;
        }

        public string SearchEngine => "Bing";

        public async Task<long> GetTotalResults(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                throw new ArgumentException("Search term can't be null or empty.", nameof(term));
            }

            var uri = new Uri(BingConfig.Current.ApiUrl)
                .AddParameter("q", term);

            var results = await _clientService.Execute(uri, HttpMethod.Get, null, BingConfig.Current.HeaderType, BingConfig.Current.AccessKey);

            if(!results.IsSuccessStatusCode)
            {
                throw new Exception($"{results.ResponseStatusCode} was thrown");
            }

            var response = JsonConvert.DeserializeObject<BingResponse>(results.ResponseBody);

            return long.Parse(response.WebPages.TotalEstimatedMatches);
        }
    }
}
