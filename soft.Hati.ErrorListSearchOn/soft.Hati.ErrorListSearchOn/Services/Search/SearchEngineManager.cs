using System.Collections.Generic;

namespace soft.Hati.ErrorListSearchOn.Services.Search
{
    public class SearchEngineManager
    {
        private static readonly IDictionary<SearchEngineTypes, SearchEngine> engines = new Dictionary<SearchEngineTypes, SearchEngine>
        {
            { SearchEngineTypes.Google, new GoogleSearch() },
            { SearchEngineTypes.Bing, new BingSearch() },
            { SearchEngineTypes.StackOverflow,  new StackOverflowSearch() }
        };

        public SearchEngineManager(SearchEngineTypes type = SearchEngineTypes.Google)
        {
            CurrentEngine = engines[type];
        }

        public IDictionary<SearchEngineTypes, SearchEngine> Engines
        {
            get { return engines; }
        }

        public SearchEngine CurrentEngine { get; set; }
    }
}