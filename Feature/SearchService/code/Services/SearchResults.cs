using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchFight.Feature.SearchService.Abstractions;
using SearchFight.Feature.SearchService.Models;

namespace SearchFight.Feature.SearchService.Services
{
    public class SearchResults : ISearchResults
    {
        private readonly IList<ISearchEngine> _searchEngines;

        public SearchResults(IEnumerable<ISearchEngine> searchEngines)
        {
            _searchEngines = searchEngines.ToList();
        }

        public async Task<IList<SearchResult>> GetSearchResults(IList<string> terms)
        {
            if (terms == null || !terms.Any()){
                throw new ArgumentException("The specified argument is invalid.", nameof(terms));
            }

            var results = new List<SearchResult>();

            foreach (var engine in _searchEngines)
            {
                foreach (var term in terms)
                {
                    results.Add(new SearchResult
                    {
                        SearchEngine = engine.SearchEngine,
                        Term = term,
                        Results = await engine.GetTotalResults(term)
                    });
                }
            }

            return results;
        }
    }
}
    