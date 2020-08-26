using System.Threading.Tasks;

namespace SearchFight.Feature.SearchService.Abstractions
{
    public interface ISearchEngine
    {
        public string SearchEngine { get; }
        Task<long> GetTotalResults(string term);
    }
}
