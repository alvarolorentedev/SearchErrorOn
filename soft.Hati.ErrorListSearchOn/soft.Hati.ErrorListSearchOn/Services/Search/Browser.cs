using System.Diagnostics;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace soft.Hati.ErrorListSearchOn.Services.Search
{
    public interface Browser
    {
        void Run(string query);

    }

    public class InternalBrowser : Browser
    {
        public void Run(string query)
        {
            IVsWindowFrame ppFrame;
            var service = Package.GetGlobalService(typeof(IVsWebBrowsingService)) as IVsWebBrowsingService;
            service.Navigate(query, (uint)__VSWBNAVIGATEFLAGS.VSNWB_ForceNew, out ppFrame);
        }
    }

    public class ExternalBrowser : Browser
    {
        public void Run(string query)
        {
            Process.Start(query);
        }
    }

    public class BrowserFactory
    {
        public static Browser Create(bool internalBrowser)
        {
            if(internalBrowser)
                return new InternalBrowser();
            else
                return new ExternalBrowser();
        }
    }
}