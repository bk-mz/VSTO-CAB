using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI;

namespace WordCAB.Common.Controls
{
    /// <summary>
    /// Интерфейс для тулбара Micosoft Word
    /// </summary>
    public interface IWordCommandBar
    {
        /// <summary>
        /// Список кнопок
        /// </summary>
        List<IWordButton> Buttons { get; }
        /// <summary>
        /// Идентификатор тулбара
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Добавить кнопку
        /// </summary>
        /// <param name="uiElement">Кнопка</param>
        void AddButton(IWordButton uiElement);
    }
}
