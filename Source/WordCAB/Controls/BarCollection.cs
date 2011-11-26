using System;
using Microsoft.Office.Core;

namespace WordCAB.Common.Controls
{
    internal class BarCollection : IWordCommandBarContainer
    {
        #region IWordCommandBarContainer Members

        public void AddBar(IWordCommandBar bar)
        {
            CommandBar commandBar = null;
            //todo: сделать так, чтобы второй раз создать нельзя было
            try
            {
                commandBar = Globals.ThisAddIn.Application.CommandBars[bar.Id];
            }
            catch ( ArgumentException ) { }

            if ( commandBar == null )
                commandBar = Globals.ThisAddIn.Application.CommandBars.Add(bar.Id, ( object )MsoBarPosition.msoBarTop, _null, true);

            commandBar.Visible = true;
        }

        private object _null = System.Reflection.Missing.Value;

        #endregion
    }
}
