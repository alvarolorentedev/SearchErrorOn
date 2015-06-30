using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using soft.Hati.ErrorListSearchOn.Services.Options;
using soft.Hati.ErrorListSearchOn.Services.Search;

namespace soft.Hati.ErrorListSearchOn
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] 
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(SearchOnPackageGuids.PackageGuidString)]
    [ProvideOptionPage(typeof(OptionPage), "Search Error On", "General", 0, 0, true)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class SearchOnPackage : Package
    {
        protected override void Initialize()
        {
            SearchOn.Initialize(this);
            base.Initialize();
        }

        public SearchEngineManager EngineManager
        {
            get
            {
                var page = (OptionPage)GetDialogPage(typeof(OptionPage));
                return page.SearchEngineManager;
            }
        }
    }
}
