using System.Windows.Forms;

namespace WordCAB.Common.Workspaces
{
    public class WindowSmartPartInfo : Microsoft.Practices.CompositeUI.WinForms.WindowSmartPartInfo
    {
        private bool _resizable = false;
        public bool Resizable
        {
            get { return _resizable; }
            set { _resizable = value; }
        }

        private bool _showInTaskbar = true;
        public bool ShowInTaskbar
        {
            get { return _showInTaskbar; }
            set { _showInTaskbar = value; }
        }

        private FormStartPosition _formStartPosition = FormStartPosition.WindowsDefaultLocation;
        public FormStartPosition FormStartPosition
        {
            get { return _formStartPosition; }
            set { _formStartPosition = value; }
        }
    }
}
