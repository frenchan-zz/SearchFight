using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Factories;
using SearchFight.Feature.SearchService.Models;

namespace SearchFight.Feature.SearchService.Tests.Factories
{
    [TestFixture]
    public class ReportResultsTest
    {
        private IReportResults _reportResults;
        
        [SetUp]
        public void Setup()
        {
            _reportResults = new ReportResults();
        }
        
        [Test]
        public void GetSearchResultsReport_Null_Terms_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportResults.GetReportResults(null));
        }

        [Test]
        public void GetSearchResultsReport_Empty_Terms_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportResults.GetReportResults(new List<SearchResult>()));
        }

        [Test]
        public void GetSearchResultsReport_Success()
        {
            var winnersReport = _reportResults.GetReportResults(GenerateTestSearchData());

            Assert.NotNull(winnersReport);
            Assert.AreNotEqual(0, winnersReport.Count());
        }

        [Test]
        public void GetWinnersReport_Null_Terms_ArgumentException()
        {            
            Assert.Throws<ArgumentException>(() => _reportResults.GetWinner(null));
        }

        [Test]
        public void GetSearchResult_Empty_Terms_ArgumentException()
        {            
            Assert.Throws<ArgumentException>(() => _reportResults.GetSearchWinnerResults(new List<SearchEngineWinner>()));
        }

        [Test]
        public void GetWinnersReport_Success()
        {
            var winnersReport = _reportResults.GetSearchWinnerResults(GetTestSearchEngineWinners());

            Assert.NotNull(winnersReport);
            Assert.AreNotEqual(0, winnersReport.Count());
        }

        [Test]
        public void GetWinnerReport_Null_Terms_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportResults.GetWinner(null));
        }

        [Test]
        public void GetWinnerReport_Success()
        {
            var grandWinnerReport = _reportResults.GetWinner(GetTestWinner());

            Assert.NotNull(grandWinnerReport);
            Assert.IsNotEmpty(grandWinnerReport);
        }

        private static SearchEngineWinner GetTestWinner()
        {
            return new SearchEngineWinner { SearchEngine = "Google", Term = ".net" };
        }

        private static IList<SearchEngineWinner> GetTestSearchEngineWinners()
        {
            return new List<SearchEngineWinner>
            {
                new SearchEngineWinner { SearchEngine = "Google", Term = ".net" },
                new SearchEngineWinner { SearchEngine = "Bing", Term = "Java" }
            };
        }

        private static List<SearchResult> GenerateTestSearchData()
        {
            var testData = new List<SearchResult>
            {
                new SearchResult { SearchEngine = "Google", Term = ".net", Results = 1500 },
                new SearchResult { SearchEngine = "Bing", Term = ".net", Results = 9500 },

                new SearchResult { SearchEngine = "Google", Term = "Java", Results = 1500 },
                new SearchResult { SearchEngine = "Bing", Term = "Java", Results = 3500 },

                new SearchResult { SearchEngine = "Google", Term = "Swift", Results = 5000 },
                new SearchResult { SearchEngine = "Bing", Term = "Swift", Results = 2000 },

                new SearchResult { SearchEngine = "Google", Term = "React", Results = 4500 },
                new SearchResult { SearchEngine = "Bing", Term = "React", Results = 3000 }
            };

            return testData;
        }
    }
}