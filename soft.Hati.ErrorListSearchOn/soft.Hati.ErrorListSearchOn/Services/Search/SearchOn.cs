using System;
using System.ComponentModel.Design;
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
                EventHandler eventHandler = SearchOnGoogle;// this.ShowMessageBox;
                MenuCommand menuItem = new MenuCommand(eventHandler, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        private void SearchOnGoogle(object sender, EventArgs e)
        {
            string message = "search selected errors:";
            var errorList = this.ServiceProvider.GetService(typeof(SVsErrorList)) as IVsTaskList2;
            IVsEnumTaskItems enumerator;
            errorList.EnumSelectedItems(out enumerator);
            var package = this.package as SearchOnPackage;
            var arr = new IVsTaskItem[1];
            
            while (enumerator.Next(1, arr, null) == 0)
            {
                string text;
                arr[0].get_Text(out text);
                package.EngineManager.CurrentEngine.Search(text);
            }
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
