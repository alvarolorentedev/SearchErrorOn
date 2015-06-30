using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using soft.Hati.ErrorListSearchOn.Services.Search;

namespace soft.Hati.ErrorListSearchOn.Services.Options
{
    [Guid("5DB71310-DD4E-4134-B67F-A4435A0EC6EC")]
    public class OptionPage : DialogPage
    {
        private readonly SearchEngineManager searchEngineManager;
        private readonly SettingStoreProvider settingStoreProvider;
        

        public OptionPage()
        {
            settingStoreProvider = new SettingStoreProvider("ErrorSearchOn");
            if (settingStoreProvider.Exist("SearchEngine"))
                searchEngineManager =
                    new SearchEngineManager(
                        (SearchEngineTypes)
                            Enum.Parse(typeof (SearchEngineTypes), settingStoreProvider.Get("SearchEngine")));
            else
                searchEngineManager = new SearchEngineManager();
        }

        public SearchEngineManager SearchEngineManager { get { return searchEngineManager; } }

        protected override IWin32Window Window
        {
            get
            {
                var page = new OptionUserControl { OptionsPage = this };
                page.OptionsPage = this;
                page.Initialize(searchEngineManager);
                return page;
            }
        }

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();
            settingStoreProvider.Set("SearchEngine", SearchEngineManager.Engines.First(item => item.Value == SearchEngineManager.CurrentEngine).Key.ToString());
        }

    }
}