using System;
using System.Diagnostics;
using System.Linq;

namespace soft.Hati.ErrorListSearchOn
{
    public class Search
    {
        public static void Google(string query)
        {
            const string url = @"http://www.google.com/search?hl=en&q=";
            query = query.Replace(' ', '+');
            var notExpectedChars = query.ToList().Where(character => (character != '+' && !char.IsLetterOrDigit(character)));
            notExpectedChars.ToList().ForEach(character => query = query.Replace(string.Format("{0}",character), Uri.HexEscape(character)));
            try
            {
                Process.Start(string.Format("{0}{1}",url,query));
            }
            catch { }
        }
    }
}