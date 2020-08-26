using System.Collections.Generic;

namespace SearchFight.Feature.SearchService.Abstractions
{
    public interface ISearchConsole
    {
        void RenderSearchFightResult(IList<string> searchResults);
    }
}