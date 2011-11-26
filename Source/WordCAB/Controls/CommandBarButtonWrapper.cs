using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Core;
using WordCAB.Common.Components;

namespace WordCAB.Common.Controls
{
    /// <summary>
    /// Обертка CommandBarButton
    /// </summary>
    internal class CommandBarButtonWrapper : IWordButton
    {
        #region Constants
        private const MsoButtonStyle DefaultStyle = MsoButtonStyle.msoButtonCaption;
        private const int DefaultIconSize = 24; 
        #endregion

        #region Ctor
        public CommandBarButtonWrapper(IWordCommandBar parent, ToolStripItemDisplayStyle style, string caption, string toolTip,
            string commandId, Image image, bool beginGroup)
        {
            _parent = parent;
            _imageDisplayStyle = style;
            _caption = caption;
            _commandId = commandId;
            _glyph = image;
            _beginsGroup = beginGroup;
			_toolTip = toolTip;
        } 
        #endregion

        #region Public Methods

        /// <summary>
        /// Создание кнопки
        /// </summary>
        public void Create()
        { 
            // todo : сделать так, чтобы нельзя было второй раз создать
            _button = ( CommandBarButton )(( CommandBarWrapper )_parent).Bar.Controls.Add(1, _null, _null, _null, _null);

            _tag = _commandId;

            _button.Caption = _caption;
			_button.TooltipText = _toolTip;
            _button.Tag = _tag;
            _button.BeginGroup = _beginsGroup;
            _button.Click += new _CommandBarButtonEvents_ClickEventHandler(Button_Click);
            _locked = false;
            _button.Enabled = !_locked;

            switch ( _imageDisplayStyle)
            {
                case ToolStripItemDisplayStyle.Image:
                    _button.Style = MsoButtonStyle.msoButtonIcon;
                    break;
                case ToolStripItemDisplayStyle.ImageAndText:
                    _button.Style = MsoButtonStyle.msoButtonIconAndCaption;
                    break;
                case ToolStripItemDisplayStyle.Text:
                    _button.Style = MsoButtonStyle.msoButtonCaption;
                    break;
                default:
                    _button.Style = DefaultStyle;
                    break;
            }

            if ( _glyph != null )
            {
                _button.Picture = AxIconConverter.Instance.Convert(_glyph);
                _button.Mask = AxIconConverter.Instance.CreateMask(_glyph);
            }
            else
                _button.Style = MsoButtonStyle.msoButtonCaption;

            Globals.ThisAddIn.Application.NormalTemplate.Saved = true;
        }

        #endregion

        #region IWordButton Members

        private IWordCommandBar _parent;
        public IWordCommandBar Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private ToolStripItemDisplayStyle _imageDisplayStyle;
        public ToolStripItemDisplayStyle ImageDisplayStyle
        {
            get { return _imageDisplayStyle; }
            set { _imageDisplayStyle = value; }
        }

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        private string _toolTip;
        public string ToolTip
        {
            get { return _toolTip; }
            set { _toolTip = value; }
        }

        private string _commandId;
        public string CommandId
        {
            get { return _commandId; }
            set { _commandId = value; }
        }

        private Image _glyph;
        public Image Glyph
        {
            get { return _glyph; }
            set { _glyph = value; }
        }

        private bool _beginsGroup;
        public bool BeginsGroup
        {
            get { return _beginsGroup; }
            set { _beginsGroup = value; }
        }

        public event EventHandler<WordButtonClickArgs> Click;

        #endregion

        #region EventHandlers

        private void Button_Click(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            if ( Click != null )
            {
                WordButtonClickArgs args = new WordButtonClickArgs();
                args.CommandId = _commandId;
                Click(this, args);
            }
        }
 
        #endregion

        #region Overrides
        public override string ToString()
        {
            return _caption;
        } 
        #endregion

        #region Private Methods
        protected void Lock()
        {
            if ( !_locked )
            {
                CommandBarButton button = ( CommandBarButton )( ( CommandBarWrapper )_parent ).Bar.FindControl(_null, _null, _tag, _null, _null);

                button.Enabled = false;
                _locked = true;
                Globals.ThisAddIn.Application.NormalTemplate.Saved = true;
            }
        }

        protected void Unlock()
        {
            if ( _locked )
            {
                CommandBarButton button = ( CommandBarButton )( ( CommandBarWrapper )_parent ).Bar.FindControl(_null, _null, _tag, _null, _null);

                button.Enabled = true;
                _locked = false;
                Globals.ThisAddIn.Application.NormalTemplate.Saved = true;
            }
        }
        #endregion

        #region Private Fields
        
        private CommandBarButton _button;
        private bool _locked = false;
        private object _null = System.Reflection.Missing.Value;
        private string _tag;
        
        #endregion

    }
}
