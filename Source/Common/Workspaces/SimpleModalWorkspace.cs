using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace WordCAB.Common.Workspaces
{
    /// <summary>
    /// Workspace показа контролов в модальном режиме
    /// </summary>
    public class SimpleModalWorkspace : IWorkspace
    {
        #region Ctor
        public SimpleModalWorkspace()
            : this(false)
        {
        }

        public SimpleModalWorkspace(bool saveControls)
        {
            _saveControls = saveControls;
        } 
        #endregion

        #region Public Properties
        /// <summary>
        /// Workitem for forms
        /// </summary>
        [ServiceDependency]
        public WorkItem WorkItem
        {
            set
            {
                Guard.ArgumentNotNull<WorkItem>(value);
                _workItem = value;
            }

            get
            {
                return _workItem;
            }
        } 

        #endregion

        #region IWorkspace Members

        public void Activate(object smartPart)
        {
            throw new NotSupportedException("Указанное действие не поддерживается");
        }

        public object ActiveSmartPart
        {
            get 
            {
                return _activeSmartPart;
            }
        }

        public void ApplySmartPartInfo(object smartPart, ISmartPartInfo smartPartInfo)
        {
            if ( _activeWrapper != null && _activeWrapper.Form != null )
                _activeWrapper.Form.Text = smartPartInfo.Title;
        }

        public void Close(object smartPart)
        {
            if ( _activeWrapper != null )
            {
                Control control = Guard.Cast<Control>(smartPart, "smartPart in windowWorkspace");

                if ( _saveControls )
                    _activeWrapper.Form.Controls.Remove(control);

                _activeWrapper.Dispose();

                _activeWrapper.Form.FormClosing -= FormClose;
                _activeWrapper.Form.Close();

                if ( SmartPartClosing != null )
                    SmartPartClosing(this, new WorkspaceCancelEventArgs(smartPart));

                _activeSmartPart = null;
                _activeWrapper = null;
            }
        }

        public void Hide(object smartPart)
        {
            if ( _activeWrapper != null && _activeWrapper.Form != null )
                _activeWrapper.Form.Hide();
        }

        public void Show(object smartPart)
        {
            WindowSmartPartInfo info = new WindowSmartPartInfo();
            Show(smartPart, info);
        }

        public void Show(object smartPart, ISmartPartInfo smartPartInfo)
        {
            if ( _activeWrapper != null )
                Close(_activeSmartPart);

            bool resizable = false;
            if (smartPartInfo is WindowSmartPartInfo)
                resizable = ((WindowSmartPartInfo)smartPartInfo).Resizable;

            Show(smartPart, smartPartInfo.Title, resizable);
        }

        public event EventHandler<WorkspaceEventArgs> SmartPartActivated;

        public event EventHandler<WorkspaceCancelEventArgs> SmartPartClosing;

        public System.Collections.ObjectModel.ReadOnlyCollection<object> SmartParts
        {
            get 
            {
                return _smartParts.AsReadOnly();
            }
        }

        #endregion

        #region Privates

        private void AddSmartPart(object smartPart)
        {
            if ( !_saveControls )
                _smartParts.Clear();

            _smartParts.Add(smartPart);
        }

        private void Show(object smartPart, string title, bool resizable)
        {
            Control control = Guard.Cast<Control>(smartPart, "SmartPart for SimpleWindowSmartPart");
            _activeWrapper = new Modal(control, resizable);

            AddSmartPart(smartPart);
            _activeSmartPart = smartPart;

            if ( SmartPartActivated != null )
                SmartPartActivated(this, new WorkspaceEventArgs(smartPart));

            _activeWrapper.Form.FormClosing += new FormClosingEventHandler(FormClose);

            _activeWrapper.ShowDialog(title);
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            Close(_activeSmartPart);
        }

        #endregion

        #region Private Fields
        private object _activeSmartPart;
        private Modal _activeWrapper;
        private WorkItem _workItem;
        private List<object> _smartParts = new List<object>();
        private bool _saveControls; 
        #endregion
    }
}

