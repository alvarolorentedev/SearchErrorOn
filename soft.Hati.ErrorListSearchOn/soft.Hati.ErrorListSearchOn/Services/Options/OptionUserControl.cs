using System;
using System.Windows.Forms;
using soft.Hati.ErrorListSearchOn.Services.Search;

namespace soft.Hati.ErrorListSearchOn.Services.Options
{
    public partial class OptionUserControl : UserControl
    {
        private SettingsManager engineManager;

        public OptionUserControl()
        {
            InitializeComponent();
        }

        internal OptionPage OptionsPage;

        public void Initialize(SettingsManager settingManager)
        {
            this.engineManager = settingManager;
            SearchEngineCB.DisplayMember = "Key";
            SearchEngineCB.ValueMember = "Value";
            SearchEngineCB.DataSource = new BindingSource(settingManager.Engines, null);
            LiteralsBC.Checked = settingManager.GeneralSearch;
        }

        private void SearchEngineCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            engineManager.CurrentEngine = (SearchEngine)SearchEngineCB.SelectedValue;
        }

        private void LiteralsBC_CheckedChanged(object sender, EventArgs e)
        {
            engineManager.GeneralSearch = LiteralsBC.Checked;
        }
    }
}
