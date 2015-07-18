using System;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace soft.Hati.ErrorListSearchOn.Services.Search
{
    internal sealed class SearchOn
    {

        public const int CommandId = 0x0100;

        public static readonly Guid MenuGroup = new Guid("36a6f571-5762-4e3b-baaa-37798d07777d");

        private readonly Package package;

        private SearchOn(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                CommandID menuCommandID = new CommandID(MenuGroup, CommandId);
                EventHandler eventHandler = SearchErrorOn;
                MenuCommand menuItem = new MenuCommand(eventHandler, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        private void SearchErrorOn(object sender, EventArgs e)
        {
            var errorList = this.ServiceProvider.GetService(typeof(SVsErrorList)) as IVsTaskList2;
            IVsEnumTaskItems enumerator;
            errorList.EnumSelectedItems(out enumerator);
            var package = this.package as SearchOnPackage;
            var arr = new IVsTaskItem[1];
            
            while (enumerator.Next(1, arr, null) == 0)
            {
                
                string error = ProcessString(arr, package.SettingsManager.GeneralSearch);
                package.SettingsManager.CurrentEngine.Search(error);
            }
        }

        private string ProcessString(IVsTaskItem[] arr, bool generalSearch)
        {
            string text;
            arr[0].get_Text(out text);
            if(generalSearch)
                text = Regex.Replace(text, "'.*'", "", RegexOptions.IgnoreCase);
            return text;
        }

        public static SearchOn Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        public static void Initialize(Package package)
        {
            Instance = new SearchOn(package);
        }
    }
}
