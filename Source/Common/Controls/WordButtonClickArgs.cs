using System;
using System.Collections.Generic;
using System.Text;

namespace WordCAB.Common.Controls
{
    public class WordButtonClickArgs : EventArgs
    {
        private string _commandId = string.Empty;
        /// <summary>
        /// Идентификатор команды, которой соответствует кнопка
        /// </summary>
        public string CommandId
        {
            get { return _commandId; }
            set { _commandId = value; }
        }
    }
}
