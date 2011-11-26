using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WordCAB.Common.Controls
{
    /// <summary>
    /// Интерфейс для кнопки на тулбаре Microsoft Word
    /// </summary>
    public interface IWordButton
    {
        /// <summary>
        /// Тулбар, которому принадлежит кнопка
        /// </summary>
        IWordCommandBar Parent { get; set; }
        /// <summary>
        /// Стиль представления изображения кнопки и текста Caption
        /// </summary>
        ToolStripItemDisplayStyle ImageDisplayStyle { get; set; }
        /// <summary>
        /// Текст кнопки
        /// </summary>
        string Caption { get; set; }
        /// <summary>
        /// Команда, которую отсылает кнопка
        /// </summary>
        string CommandId { get; set; }
        /// <summary>
        /// Изображение
        /// </summary>
        Image Glyph { get; set; }
        /// <summary>
        /// Флаг: кнопка начинает группу
        /// </summary>
        bool BeginsGroup { get; set; }
        /// <summary>
        /// Событие нажатия кнопки
        /// </summary>
        event EventHandler<WordButtonClickArgs> Click;
    }
}
