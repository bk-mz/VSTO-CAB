using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace WordCAB.CustomModule.SmartParts
{
    [SmartPart]
    public partial class SampleSmartPart : UserControl, ISampleSmartPart
    {
        #region Ctor
        public SampleSmartPart()
        {
            InitializeComponent();
        } 
        #endregion

        #region Public Properties
        private SampleSmartPartPresenter _presenter;
        [CreateNew]
        public SampleSmartPartPresenter Presenter
        {
            set { _presenter = value; _presenter.View = this; }
        } 
        #endregion

        #region ISampleSmartPart Members

        public event EventHandler GetText;

        public string TextBoxText
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        #endregion

        #region Event Handlers
        private void button1_Click(object sender, EventArgs e)
        {
            if ( this.GetText != null )
                GetText(this, EventArgs.Empty);
        } 
        #endregion
    }
}
