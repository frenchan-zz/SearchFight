using SearchFight.Feature.SearchService.Abstractions;

namespace SearchFight.Feature.SearchService.Presenters
{
    public class SearchCtorArgs
    {
        public ISearchResults SearchResults { get; set; }
        public IWinnerResults WinnerResults { get; set; }
        public IReportResults ReportResults { get; set; }
        public ISearchConsole SearchConsole { get; set; }


        public SearchCtorArgs(){}

        public SearchCtorArgs(ISearchResults searchResults, IWinnerResults winnerResults, IReportResults reportResults, ISearchConsole searchConsole)
        {
            SearchResults = searchResults;
            WinnerResults = winnerResults;
            ReportResults = reportResults;
            SearchConsole = searchConsole;
        }
    }
}