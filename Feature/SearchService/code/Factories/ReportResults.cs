using System;
using System.Collections.Generic;
using System.Linq;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Models;

namespace SearchFight.Feature.SearchService.Factories
{
    public class ReportResults : IReportResults
    {
        public IEnumerable<string> GetReportResults(IList<SearchResult> searchResults)
        {
            if(searchResults == null || !searchResults.Any())
            {
                throw new ArgumentException("The specified parameter is invalid", nameof(searchResults));
            }

            var list = new List<string>();

            foreach(var group in searchResults.GroupBy(x => x.Term))
            {
                list.Add($"{group.Key}: {string.Join(" ", group.Select(item => $"{item.SearchEngine}: {item.Results}"))}");
            }

            return list;
        }

        public IEnumerable<string> GetSearchWinnerResults(IList<SearchEngineWinner> searchEngineWinners)
        {
            if(searchEngineWinners == null || !searchEngineWinners.Any())
            {
                throw new ArgumentException("The specified parameter is invalid", nameof(searchEngineWinners));
            }
            
            return searchEngineWinners.Select(winner => $"{winner.SearchEngine} winner: {winner.Term}").ToList();
        }

        public string GetWinner(SearchEngineWinner winner)
        {
            if(winner == null)
            {
                throw new ArgumentException("Parameter is invalid, null object is not valid", nameof(winner));
            }

            return $"{Constants.Results.TOTAL_WINNER}{winner.SearchEngine}";
        }
    }
}
