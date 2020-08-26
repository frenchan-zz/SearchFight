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
    public class GoogleTest
    {
        ISearchEngine _searchEngine;
        IClientService _clientService;
        ILoggerFactory mockLogger;

        [SetUp]
        public void SetUp()
        {
            mockLogger = Mock.Of<ILoggerFactory>();
            _clientService = new ApiClientService(mockLogger);
            _searchEngine = new GoogleSearch(_clientService);
        }

        [Test]
        public void GetResultsFromGoogle_Null_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResults(null));
        }

        [Test]
        public void GetResultsFromGoogle_Empty_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResults(string.Empty));
        }

        [Test]
        public async Task GetResultsFromGoogle_Success()
        {
            var result = await _searchEngine.GetTotalResults("steve jobs");

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<long>(result);
        }
    }
}
