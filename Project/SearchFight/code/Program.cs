using SearchFight.Foundation.ClientService.Abstractions;
using SearchFight.Foundation.ClientService.Services;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Factories;
using SearchFight.Feature.SearchService.Presenters;
using SearchFight.Feature.SearchService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services
                .AddSingleton<IClientService, ApiClientService>()
                .AddSingleton<ISearchEngine, BingSearch>()
                .AddSingleton<ISearchEngine, GoogleSearch>()
                .AddSingleton<ISearchResults, SearchResults>()
                .AddSingleton<IWinnerResults, WinnerResults>()
                .AddSingleton<IReportResults, ReportResults>()
                .AddSingleton<ISearchConsole, SearchConsole>()
                .AddSingleton<SearchCtorArgs>()
                .AddSingleton<SearchPresenter>()
                .AddLogging();

            var provider = services.BuildServiceProvider();
            var presenter = provider.GetRequiredService<SearchPresenter>();

            presenter.SearchAndFight(args);
        }
    }
}
