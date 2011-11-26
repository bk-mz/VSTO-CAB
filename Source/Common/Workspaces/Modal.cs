using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WordCAB.Common.Workspaces
{
    /// <summary>
    /// Класс, инкапсулирующий логику показа контрола в модальном режиме
    /// </summary>
    public class Modal : IDisposable
    {
        #region Constructors
        public Modal(Control control)
            : this(control, false)
        {
        }

        public Modal(Control control, bool resizable)
        {
            _form = new Form();
            _form.SuspendLayout();
            _form.ClientSize = control.Size;

            if ( !control.MinimumSize.IsEmpty )
            {
                Size delta = Size.Subtract(_form.Size, _form.ClientSize);
                _form.MinimumSize = Size.Add(control.MinimumSize, delta);
            }

            control.Dock = DockStyle.Fill;

            _form.FormBorderStyle = resizable ? FormBorderStyle.Sizable
                : FormBorderStyle.FixedSingle;

            _form.AutoScroll = true;
            _form.MaximizeBox = resizable;
            _form.MinimizeBox = resizable;
            _form.ShowInTaskbar = resizable;
            _form.Text = string.Empty;
            _form.ShowIcon = false;
            _form.StartPosition = FormStartPosition.CenterScreen;
            _form.Controls.Add(control);
            _form.ResumeLayout();
        }
        #endregion

        #region Public members

        public Form Form
        {
            get { return _form; }
        }

        /// <summary>
        /// Покажет контрол в модальном режиме
        /// </summary>
        public DialogResult ShowDialog()
        {
            return _form.ShowDialog();
        }

        /// <summary>
        /// Покажет контрол в модальном режиме (с указанным текстом в качестве заголовка формы)
        /// </summary>
        public DialogResult ShowDialog(string caption)
        {
            _form.Text = caption;
            return ShowDialog();
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Implements IDisposable.Dispose
        /// </summary>
        public virtual void Dispose()
        {
        }

        #endregion

        #region Private members
        protected Form _form;
        #endregion
    }
}
