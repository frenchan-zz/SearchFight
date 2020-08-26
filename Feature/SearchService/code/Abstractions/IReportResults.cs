using System.Collections.Generic;
using SearchFight.Feature.SearchService.Models;

namespace SearchFight.Feature.SearchService.Abstractions
{
    public interface IReportResults
    {
        IEnumerable<string> GetReportResults(IList<SearchResult> searchResults);
        IEnumerable<string> GetSearchWinnerResults(IList<SearchEngineWinner> searchEngineWinners);
        string GetWinner(SearchEngineWinner winner);
    }
}
