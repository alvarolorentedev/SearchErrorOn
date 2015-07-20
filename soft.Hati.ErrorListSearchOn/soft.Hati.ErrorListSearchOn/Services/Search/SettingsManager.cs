using System.Collections.Generic;

namespace soft.Hati.ErrorListSearchOn.Services.Search
{
    public class SettingsManager
    {
        private static readonly IDictionary<SearchEngineTypes, SearchEngine> engines = new Dictionary<SearchEngineTypes, SearchEngine>
        {
            { SearchEngineTypes.Google, new GoogleSearch() },
            { SearchEngineTypes.Bing, new BingSearch() },
            { SearchEngineTypes.StackOverflow,  new StackOverflowSearch() },
            { SearchEngineTypes.DuckDuckGo, new DuckDuckGo() }
        };

        public SettingsManager(SearchEngineTypes type = SearchEngineTypes.Google, bool generalSearch = false, bool internalBrowser = false)
        {
            CurrentEngine = engines[type];
            GeneralSearch = generalSearch;
            InternalBrowser = internalBrowser;
        }

        public IDictionary<SearchEngineTypes, SearchEngine> Engines
        {
            get { return engines; }
        }

        public bool GeneralSearch { get; set; }
        public bool InternalBrowser { get; set; }
        public SearchEngine CurrentEngine { get; set; }
    }
}