using System;
using System.Collections.Generic;
using System.Linq;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Models;
using SearchFight.Foundation.Utilities.Extensions;

namespace SearchFight.Feature.SearchService.Factories
{
    public class WinnerResults : IWinnerResults
    {
        public SearchEngineWinner GetWinner(IList<SearchResult> searchData)
        {
            if (searchData == null || !searchData.Any()) 
            {
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));
            }

            var searchWinner = searchData.GetMax(item => item.Results);
            return new SearchEngineWinner() { SearchEngine = searchWinner.SearchEngine, Term = searchWinner.Term };
        }

        public IEnumerable<SearchEngineWinner> GetSearchEngineWinners(IList<SearchResult> searchData)
        {
            if (searchData == null || !searchData.Any()) 
            {
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));
            }

            var searchEngines = searchData.GroupBy(data => data.SearchEngine,
                result => result, (searchEngine, results) => new SearchEngineWinner
                {
                    SearchEngine = searchEngine,
                    Term = results.GetMax(item => item.Results).Term
                });

            return searchEngines;
        }
    }
}