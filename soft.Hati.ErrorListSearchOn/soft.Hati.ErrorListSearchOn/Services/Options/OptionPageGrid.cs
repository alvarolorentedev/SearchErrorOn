using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using soft.Hati.ErrorListSearchOn.Services.Search;

namespace soft.Hati.ErrorListSearchOn.Services.Options
{
    [Guid("5DB71310-DD4E-4134-B67F-A4435A0EC6EC")]
    public class OptionPage : DialogPage
    {
        private static readonly SearchEngineManager searchEngineManager = new SearchEngineManager();

        public SearchEngineManager SearchEngineManager { get { return searchEngineManager; } }

        protected override IWin32Window Window
        {
            get
            {
                var page = new OptionUserControl { optionsPage = this };
                page.optionsPage = this;
                page.Initialize(searchEngineManager);
                return page;
            }
        }
    }
}