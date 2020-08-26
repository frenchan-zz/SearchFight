using System;
using System.Collections.Generic;
using SearchFight.Feature.SearchService.Abstractions;

namespace SearchFight.Feature.SearchService.Presenters
{
    public class SearchConsole : ISearchConsole
    {
        public void RenderSearchFightResult(IList<string> results)
        {
            if (results == null)
            {
                throw new ArgumentException("The specified parameter is invalid", nameof(results));
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}