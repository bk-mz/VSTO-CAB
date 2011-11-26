using System;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI.WinForms;

namespace WordCAB
{
    internal sealed class AddInApplication : WindowsFormsApplication<AddInWorkItem, object>
    {
        protected override void Start()
        {
        }

        protected override void AddServices()
        {
            base.AddServices();

            RootWorkItem.Services.Remove<IModuleEnumerator>();
            RootWorkItem.Services.AddOnDemand<CustomModuleEnumerator, IModuleEnumerator>();
        }
    }
}
