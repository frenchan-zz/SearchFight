using System.Collections.Generic;
using System.Linq;
using SearchFight.Feature.SearchService.Abstractions;

namespace SearchFight.Feature.SearchService.Presenters
{
    public class SearchPresenter
    {
        public SearchPresenter(SearchCtorArgs args)
        {
            Results = args.SearchResults;
            WinnerResults = args.WinnerResults;
            ReportResults = args.ReportResults;
            SearchConsole = args.SearchConsole;
        }

        public ISearchResults Results { get; set; }
        public IWinnerResults WinnerResults { get; set; }
        public IReportResults ReportResults { get; set; }
        public ISearchConsole SearchConsole { get; set; }

        public void SearchAndFight(IList<string> terms)
        {
            var results = Results.GetSearchResults(terms).Result;
            var searchWinner = WinnerResults.GetSearchEngineWinners(results);
            var winner = WinnerResults.GetWinner(results);
            
            var reportList = new List<string>();

            reportList.AddRange(ReportResults.GetReportResults(results));
            reportList.AddRange(ReportResults.GetSearchWinnerResults(searchWinner.ToList()));
            reportList.Add(ReportResults.GetWinner(winner));
            
            SearchConsole.RenderSearchFightResult(reportList);
            
        }
    }
}