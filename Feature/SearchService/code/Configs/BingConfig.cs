using System.IO;
using SearchFight.Foundation.Configuration;
using Microsoft.Extensions.Configuration;

namespace SearchFight.Feature.SearchService.Configs
{
    public class BingConfig : BaseConfig<BingConfig>
    {
        private BingConfig()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("SearchConfig.json")
                .Build();

            ApiUrl = configuration["SearchFight:BingApiUrl"];
            AccessKey = configuration["SearchFight:BingAccessKey"];
            HeaderType = configuration["SearchFight:BingHeaderType"];
        }

        public string ApiUrl { get; private set; }
        public string AccessKey { get; private set; }
        public string HeaderType { get; private set; }
    }
}
