using SearchFight.Foundation.Configuration;
using Microsoft.Extensions.Configuration;

namespace SearchFight.Feature.SearchService.Configs
{
    public class GoogleConfig : BaseConfig<GoogleConfig>
    {
        private GoogleConfig()
        {
            var basePath = System.AppContext.BaseDirectory;
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("SearchConfig.json")
                .Build();


            ApiUrl = configuration["SearchFight:GoogleApiUrl"];
            ApiKey = configuration["SearchFight:GoogleApiKey"];
            ContextId = configuration["SearchFight:GoogleContextId"];
        }

        public string ApiUrl { get; private set; }
        public string ApiKey { get; private set; }
        public string ContextId { get; private set; }
    }
}
