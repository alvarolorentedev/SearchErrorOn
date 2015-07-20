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
        private readonly SettingsManager settingsManager;
        private readonly SettingStoreProvider settingStoreProvider;
        

        public OptionPage()
        {
            settingStoreProvider = new SettingStoreProvider("ErrorSearchOn");
            if (settingStoreProvider.Exist("SearchEngine") && settingStoreProvider.Exist("GeneralSearch") && settingStoreProvider.Exist("InternalBrowser"))
                settingsManager =
                    new SettingsManager((SearchEngineTypes)Enum.Parse(typeof (SearchEngineTypes), settingStoreProvider.Get("SearchEngine")),
                                        Convert.ToBoolean(settingStoreProvider.Get("GeneralSearch")),
                                        Convert.ToBoolean(settingStoreProvider.Get("InternalBrowser")));
            else
                settingsManager = new SettingsManager();
        }

        public SettingsManager SettingsManager { get { return settingsManager; } }

        protected override IWin32Window Window
        {
            get
            {
                var page = new OptionUserControl { OptionsPage = this };
                page.OptionsPage = this;
                page.Initialize(settingsManager);
                return page;
            }
        }

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();
            settingStoreProvider.Set("SearchEngine", SettingsManager.Engines.First(item => item.Value == SettingsManager.CurrentEngine).Key.ToString());
            settingStoreProvider.Set("GeneralSearch", SettingsManager.GeneralSearch.ToString());
            settingStoreProvider.Set("InternalBrowser", SettingsManager.InternalBrowser.ToString());
        }

    }
}