//------------------------------------------------------------------------------
// <copyright file="SearchOn.cs" company="Hatisoft">
//     Copyright (c) Hatisoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace soft.Hati.ErrorListSearchOn
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class SearchOn
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid MenuGroup = new Guid("36a6f571-5762-4e3b-baaa-37798d07777d");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOn"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
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
            var arr = new IVsTaskItem[1];
            
            while (enumerator.Next(1, arr, null) == 0)
            {
                string text;
                arr[0].get_Text(out text);
                Search.Google(text);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static SearchOn Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new SearchOn(package);
        }
    }
}
