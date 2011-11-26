using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.UIElements;
using WordCAB.Common;
using WordCAB.Common.Controls;
using WordCAB.Common.Extensions;
using WordCAB.Common.Services;
using WordCAB.Common.Workspaces;
using WordCAB.Controls;
using WordCAB.Services;

namespace WordCAB
{
    /// <summary>
    /// RootWorkItem
    /// </summary>
    internal sealed class AddInWorkItem : WorkItem
    {
        protected override void InitializeServices()
        {
            base.InitializeServices();
            Services.AddNew<WordUIElementFactory, IWordUIElementFactory>();
            IUIElementAdapterFactoryCatalog factoryService = base.Services.Get<IUIElementAdapterFactoryCatalog>();
            factoryService.RegisterFactory(new CommandBarUIAdapterFactory());

            UIExtensionSites.RegisterSite(UIExtensionSiteNames.WordBarsSite, new BarCollection());

            Services.AddNew<WordSelectionGetter, IWordSelectionGetter>();
            Workspaces.Add(( new SimpleModalWorkspace() ), WorkspaceNames.MainWorkspace);
        }

        #region IDisposable
        private bool _dispose = false;

        protected override void Dispose(bool disposing)
        {
            if ( _dispose )
            {
                base.Dispose(disposing);
            }
        }

        #endregion
    }
}
