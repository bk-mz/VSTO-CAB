using System;
using System.Collections.Generic;
using System.Text;

namespace WordCAB.CustomModule.SmartParts
{
    public interface ISampleSmartPart
    {
        /// <summary>
        /// Эвент запроса View текста
        /// </summary>
        event EventHandler GetText;
        /// <summary>
        /// Текст View
        /// </summary>
        string TextBoxText { get; set; }
    }
}
