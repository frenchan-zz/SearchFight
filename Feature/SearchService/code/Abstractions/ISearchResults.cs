using System.Collections.Generic;
using System.Threading.Tasks;
using SearchFight.Feature.SearchService.Models;

namespace SearchFight.Feature.SearchService.Abstractions
{
    public interface ISearchResults
    {
        Task<IList<SearchResult>> GetSearchResults(IList<string> terms);
    }
}
