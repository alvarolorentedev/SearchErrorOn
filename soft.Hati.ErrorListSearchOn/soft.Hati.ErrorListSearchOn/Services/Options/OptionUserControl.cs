using System;
using System.Windows.Forms;
using soft.Hati.ErrorListSearchOn.Services.Search;

namespace soft.Hati.ErrorListSearchOn.Services.Options
{
    public partial class OptionUserControl : UserControl
    {
        private SearchEngineManager engineManager;

        public OptionUserControl()
        {
            InitializeComponent();
        }

        internal OptionPage OptionsPage;

        public void Initialize(SearchEngineManager engineManager)
        {
            this.engineManager = engineManager;
            SearchEngineCB.DisplayMember = "Key";
            SearchEngineCB.ValueMember = "Value";
            SearchEngineCB.DataSource = new BindingSource(engineManager.Engines, null);
        }

        private void SearchEngineCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            engineManager.CurrentEngine = (SearchEngine)SearchEngineCB.SelectedValue;
        }
    }
}
