using System;
using System.Diagnostics;
using System.Linq;

namespace soft.Hati.ErrorListSearchOn.Services.Search
{
    public interface SearchEngine
    {
        void Search(string query);
        string GenerateQuery(string info);
    }

    public abstract class SearchBase : SearchEngine
    {
        protected abstract string Url { get; }

        public void Search(string query)
        {
            query = query.Replace(' ', '+');
            var notExpectedChars = query.ToList().Where(character => (character != '+' && !char.IsLetterOrDigit(character)));
            notExpectedChars.ToList().ForEach(character => query = query.Replace(string.Format("{0}", character), Uri.HexEscape(character)));
            try
            {
                Process.Start(string.Format("{0}{1}", Url, query));
            }
            catch { }
        }

        public string GenerateQuery(string info)
        {
            info = info.Replace(' ', '+');
            var notExpectedChars = info.ToList().Where(character => (character != '+' && !char.IsLetterOrDigit(character)));
            notExpectedChars.ToList().ForEach(character => info = info.Replace(string.Format("{0}", character), Uri.HexEscape(character)));
            return string.Format("{0}{1}", Url, info);
        }
    }

    public class GoogleSearch : SearchBase
    {
        protected override string Url { get { return @"http://www.google.com/search?q="; } }
    }

    public class BingSearch : SearchBase
    {
        protected override string Url { get { return @"http://www.bing.com/search?q="; } }
    }

    public class StackOverflowSearch : SearchBase
    {
        protected override string Url { get { return @"http://stackoverflow.com/search?q="; } }
    }

    public class DuckDuckGo : SearchBase
    {
        protected override string Url { get { return @"https://duckduckgo.com/?q="; } }
    }
}