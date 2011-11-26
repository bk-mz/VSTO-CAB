using System;
using System.Collections.Generic;
using System.Text;

namespace WordCAB.Common.Services
{
    /// <summary>
    /// Интерфейс сервиса получения выделенного текста в Microsoft Word
    /// </summary>
    public interface IWordSelectionGetter
    {
        /// <summary>
        /// Получить выбранный в Microsoft Word выделенный текст
        /// </summary>
        /// <returns>Текст</returns>
        string GetText();
    }
}
