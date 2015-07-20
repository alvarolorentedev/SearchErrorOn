using System;
using System.Windows.Forms;
using soft.Hati.ErrorListSearchOn.Services.Search;

namespace soft.Hati.ErrorListSearchOn.Services.Options
{
    public partial class OptionUserControl : UserControl
    {
        private SettingsManager settingsManager;

        public OptionUserControl()
        {
            InitializeComponent();
        }

        internal OptionPage OptionsPage;

        public void Initialize(SettingsManager settingManager)
        {
            this.settingsManager = settingManager;
            SearchEngineCB.DisplayMember = "Key";
            SearchEngineCB.ValueMember = "Value";
            SearchEngineCB.DataSource = new BindingSource(settingManager.Engines, null);
            SearchEngineCB.SelectedValue = settingManager.CurrentEngine;
            LiteralsBC.Checked = settingManager.GeneralSearch;
            InternalBrowserCB.Checked = settingManager.InternalBrowser;
        }

        private void SearchEngineCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            settingsManager.CurrentEngine = (SearchEngine)SearchEngineCB.SelectedValue;
        }

        private void LiteralsBC_CheckedChanged(object sender, EventArgs e)
        {
            settingsManager.GeneralSearch = LiteralsBC.Checked;
        }

        private void InternalBrowserCB_CheckedChanged(object sender, EventArgs e)
        {
            settingsManager.InternalBrowser = InternalBrowserCB.Checked;
        }
    }
}
