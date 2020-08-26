namespace SearchFight.Feature.SearchService.Models
{
    public class SearchResult
    {
        public string SearchEngine { get; set; }
        public string Term { get; set; }
        public long Results { get; set; }
    }
}
