using System;
using System.Threading.Tasks;
using SearchFight.Foundation.ClientService.Abstractions;
using SearchFight.Foundation.ClientService.Services;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace SearchFight.Feature.SearchService.Tests.Services
{
    [TestFixture()]
    public class BingTest
    {
        ISearchEngine _searchEngine;
        IClientService _clientService;
        ILoggerFactory _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = Mock.Of<ILoggerFactory>();
            _clientService = new ApiClientService(_mockLogger);
            _searchEngine = new BingSearch(_clientService);
        }

        [Test]
        public void GetResultsFromBing_Null_Query_ArgumentException()
        {
           
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResults(null));
        }

        [Test]
        public void GetResultsFromBing_Empty_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResults(string.Empty));
        }

        [Test]
        public async Task GetResultsFromBing_Success()
        {
            var result = await _searchEngine.GetTotalResults("bing");

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<long>(result);
        }
    }
}