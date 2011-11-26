using System;
using System.Collections.Generic;
using System.Text;
using WordCAB.Common.Extensions;
using Microsoft.Practices.CompositeUI;
using System.Windows.Forms;
using System.Drawing;
using WordCAB.Common.Controls;

namespace WordCAB.Common.Extensions
{
    /// <summary>
    /// Фабрика элементов управления Microsoft Word
    /// </summary>
    public interface IWordUIElementFactory
    {
        /// <summary>
        /// Создание кнопки
        /// </summary>
	    IWordButton CreateButton(IWordCommandBar parent, string commandId, ToolStripItemDisplayStyle style, string caption, string toolTip,
		     Image image, bool beginGroup);

        /// <summary>
        /// Создание тулбара
        /// </summary>
        IWordCommandBar CreateBar(string id);
    }
}
