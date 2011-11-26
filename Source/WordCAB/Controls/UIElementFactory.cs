using System.Drawing;
using System.Windows.Forms;
using WordCAB.Common.Controls;
using WordCAB.Common.Extensions;

namespace WordCAB.Controls
{
    internal class WordUIElementFactory : IWordUIElementFactory
    {
        #region IUiElementFactory Members

        public IWordButton CreateButton(IWordCommandBar parent, string commandId, ToolStripItemDisplayStyle style, string caption, string toolTip,
             Image image, bool beginGroup)
        {
            CommandBarButtonWrapper wrapper = new CommandBarButtonWrapper(
                parent, style, caption, toolTip, commandId, image, beginGroup);

            return wrapper;
        }

        public IWordCommandBar CreateBar(string id)
        {
            CommandBarWrapper wrapper = new CommandBarWrapper(id);
            return wrapper;
        }

        #endregion
    }
}
