using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.UIElements;
using WordCAB.Common.Controls;

namespace WordCAB.Common.Extensions
{
    public class CommandBarButtonUIAdapter : UIElementAdapter<IWordButton>
    {
        public CommandBarButtonUIAdapter(IWordCommandBar bar)
        {
            _bar = Guard.ArgumentNotNull<IWordCommandBar>(bar);
        }

        protected override IWordButton Add(IWordButton uiElement)
        {
            _bar.AddButton(uiElement);
            return uiElement;
        }

        protected override void Remove(IWordButton uiElement)
        {
            throw new NotSupportedException("Удаление кнопок не поддерживается");
        }

        private IWordCommandBar _bar;
    }
}
