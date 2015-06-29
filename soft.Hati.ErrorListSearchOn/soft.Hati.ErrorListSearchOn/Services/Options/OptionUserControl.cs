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

        internal OptionPage optionsPage;

        public void Initialize(SearchEngineManager engineManager)
        {
            this.engineManager = engineManager;
            SearchEngineCB.DisplayMember = "Key";
            SearchEngineCB.ValueMember = "Value";
            SearchEngineCB.DataSource = new BindingSource(engineManager.Engines, null);
        }

        private void SearchEngineCB_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            engineManager.CurrentEngine = (SearchEngine)SearchEngineCB.SelectedValue;
        }
    }
}
