using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using WordCAB.Common;
using WordCAB.Common.Controls;
using WordCAB.Common.Extensions;
using WordCAB.Common.Workspaces;
using WordCAB.CustomModule.Properties;
using WordCAB.CustomModule.SmartParts;

namespace WordCAB.CustomModule
{
    public class Module : ModuleInit
    {
        public Module([ServiceDependency] WorkItem rootWorkItem,
            [ServiceDependency]IWordUIElementFactory elementFactory)
        {
            _rootWorkItem = rootWorkItem;
            _factory = elementFactory;
        }

        public override void Load()
        {
            base.Load();

            UIExtensionSite site = _rootWorkItem.UIExtensionSites[UIExtensionSiteNames.WordBarsSite];
            IWordCommandBar mainBar = site.Add<IWordCommandBar>(_factory.CreateBar("AddInToolbar"));

            IWordButton btn = _factory.CreateButton(mainBar, CommandNames.OpenForm, ToolStripItemDisplayStyle.ImageAndText, "Открыть окно",
                "Открыть форму просмотра Custom Control", Resources.OpenForm, false);

            mainBar.AddButton(btn);
            btn.Click += new EventHandler<WordButtonClickArgs>(ButtonClick);
        }

        public override void AddServices()
        {
            base.AddServices();

            _rootWorkItem.Commands.AddNew<Command>(CommandNames.OpenForm);
        }

        private void ButtonClick(object sender, WordButtonClickArgs e)
        {
            object smartPart = _rootWorkItem.SmartParts.AddNew<SampleSmartPart>();
            WindowSmartPartInfo info = new WindowSmartPartInfo();
            info.FormStartPosition = FormStartPosition.CenterScreen;
            info.MaximizeBox = false;
            info.MinimizeBox = false;
            info.Resizable = false;
            info.Title = "Custom Control";
            info.ShowInTaskbar = false;
            _rootWorkItem.Workspaces[WorkspaceNames.MainWorkspace].Show(smartPart, info);
        }

        private WorkItem _rootWorkItem;
        private IWordUIElementFactory _factory;
    }
}
