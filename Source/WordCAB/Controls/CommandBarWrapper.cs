using System.Collections.Generic;
using Microsoft.Office.Core;

namespace WordCAB.Common.Controls
{
    /// <summary>
    /// Обертка над CommandBar
    /// </summary>
    internal class CommandBarWrapper : IWordCommandBar
    {
        #region Ctor
        public CommandBarWrapper(string id)
        {
            _id = id;           
        } 
        #endregion

        #region Public Properties
        public CommandBar Bar
        {
            get { return (CommandBar)Globals.ThisAddIn.Application.CommandBars[_id]; }
        }
        #endregion

        #region Public Methods

        public void AddButton(IWordButton button)
        {
            _buttons.Add(button);
            ( ( CommandBarButtonWrapper )button ).Create();
        }

        #endregion

        #region IWordCommandBar Members

        public List<IWordButton> Buttons
        {
            get { return _buttons; }
        }

        public string Id
        {
            get { return _id; }
        }

        #endregion

        #region Private Fields
        private List<IWordButton> _buttons = new List<IWordButton>();
        private string _id = string.Empty;
        private object _null = System.Reflection.Missing.Value; 
        #endregion
    }
}
