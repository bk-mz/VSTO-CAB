using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;

namespace WordCAB.Common.Workspaces
{
    /// <summary>
    /// Класс, инкапсулирующий логику показа контрола в модальном режиме (с поддержкой CAB)
    /// </summary>
    public class CabModal : Modal
    {
        #region Constructors
        public CabModal(WorkItem workItem, Control control) 
            : this(workItem, control, false)
        {
        }

        public CabModal(WorkItem workItem, Control control, bool resizable)
            : base(control, resizable)
        {
            _workItem = workItem;
            workItem.Items.Add(_form);
        }
        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
            _workItem.Items.Remove(_form);
        }

        #endregion

        #region Private members
        protected WorkItem _workItem;
        #endregion
    }
}
