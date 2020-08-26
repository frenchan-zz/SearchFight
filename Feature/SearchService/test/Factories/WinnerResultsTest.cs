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
    public class WinnerResultsTest
    {
        IWinnerResults _winnerResults;
        
        [SetUp]
        public void SetUp()
        {
            _winnerResults = new WinnerResults();
        }
        
        [Test]
        public void GetSearchEngineWinners_Null_Terms_ArgumentException()
        {
            List<SearchResult> searchData = null;
            
            Assert.Throws<ArgumentException>(() => _winnerResults.GetSearchEngineWinners(searchData));
        }

        [Test]
        public void GetSearchEngineWinners_Empty_Terms_ArgumentException()
        {
            var searchData = new List<SearchResult>();
            Assert.Throws<ArgumentException>(() => _winnerResults.GetSearchEngineWinners(searchData));
        }

        [Test]
        public void GetSearchEngineWinners_Success()
        {
            var searchEngineWinners = _winnerResults.GetSearchEngineWinners(GenerateTestData()).ToList();

            Assert.IsNotNull(searchEngineWinners);
            Assert.IsNotEmpty(searchEngineWinners);

            Assert.AreEqual("react", searchEngineWinners.First(x => x.SearchEngine == "Google").Term);
            Assert.AreEqual(".net", searchEngineWinners.First(x => x.SearchEngine == "Bing").Term);           
        }

        [Test]
        public void GetWinner_Null_Terms_ArgumentException()
        {
            List<SearchResult> searchData = null;
            Assert.Throws<ArgumentException>(() => _winnerResults.GetWinner(searchData));
        }

        [Test]
        public void GetWinner_Empty_Terms_ArgumentException()
        {
            var searchData = new List<SearchResult>();
            Assert.Throws<ArgumentException>(() => _winnerResults.GetWinner(searchData));
        }

        [Test]
        public void GetWinner_Success()
        {
            var winner = _winnerResults.GetWinner(GenerateTestData());

            Assert.IsNotNull(winner);

            Assert.AreEqual("Bing", winner.SearchEngine);
            Assert.AreEqual(".net", winner.Term);
        }

        private static IList<SearchResult> GenerateTestData()
        {
            var testData = new List<SearchResult>
            {
                new SearchResult { SearchEngine = "Google", Term = ".net", Results = 1000 },
                new SearchResult { SearchEngine = "Bing", Term = ".net", Results = 9800 },

                new SearchResult { SearchEngine = "Google", Term = "java", Results = 1300 },
                new SearchResult { SearchEngine = "Bing", Term = "java", Results = 3100 },

                new SearchResult { SearchEngine = "Google", Term = "swift", Results = 3100 },
                new SearchResult { SearchEngine = "Bing", Term = "swift", Results = 1300 },

                new SearchResult { SearchEngine = "Google", Term = "react", Results = 3900 },
                new SearchResult { SearchEngine = "Bing", Term = "react", Results = 3100 }
            };

            return testData;
        }
    }
}