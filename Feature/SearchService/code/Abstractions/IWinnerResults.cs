using System.Collections.Generic;
using SearchFight.Feature.SearchService.Models;

namespace SearchFight.Feature.SearchService.Abstractions
{
    public interface IWinnerResults
    {
        SearchEngineWinner GetWinner(IList<SearchResult> searchData);
        IEnumerable<SearchEngineWinner> GetSearchEngineWinners(IList<SearchResult> searchData);
    }
}