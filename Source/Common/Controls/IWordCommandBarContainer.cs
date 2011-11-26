using System;
using System.Collections.Generic;
using System.Text;

namespace WordCAB.Common.Controls
{
    /// <summary>
    /// Контейнер тулбаров для Microsoft Word
    /// </summary>
    public interface IWordCommandBarContainer
    {
        /// <summary>
        /// Добавить тулбар
        /// </summary>
        /// <param name="bar">тулбар</param>
        void AddBar(IWordCommandBar bar);
    }
}
