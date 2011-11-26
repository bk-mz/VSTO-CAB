using System;
using System.Collections.Generic;
using System.Text;
using WordCAB.Common.Services;

namespace WordCAB.Services
{
    class WordSelectionGetter : IWordSelectionGetter
    {
        #region IWordSelectionGetter Members

        public string GetText()
        {
            return Globals.ThisAddIn.Application.Selection.Range.Text;
        }

        #endregion
    }
}
