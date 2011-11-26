using System;
using System.Collections.Generic;
using System.Text;
using WordCAB.Common.MVP;
using Microsoft.Practices.ObjectBuilder;
using WordCAB.Common.Services;
using Microsoft.Practices.CompositeUI;

namespace WordCAB.CustomModule.SmartParts
{
    /// <summary>
    /// Презентер для ISampleSmartPart
    /// </summary>
    public class SampleSmartPartPresenter : Presenter<ISampleSmartPart>
    {
        #region Ctor
        [InjectionConstructor]
        public SampleSmartPartPresenter([ServiceDependency]IWordSelectionGetter service)
        {
            _service = service;
        } 
        #endregion

        #region Overrides
        protected override void OnViewSet()
        {
            base.OnViewSet();
            View.GetText += new EventHandler(GetText);
        } 
        #endregion

        #region Event Handlers
        private void GetText(object sender, EventArgs e)
        {
            View.TextBoxText = _service.GetText();
        } 
        #endregion

        #region Private Fields
        private IWordSelectionGetter _service; 
        #endregion
    }
}
