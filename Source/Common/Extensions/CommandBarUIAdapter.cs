using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.UIElements;
using WordCAB.Common.Controls;

namespace WordCAB.Common.Extensions
{
    public class CommandBarUIAdapter : UIElementAdapter<IWordCommandBar>
    {
        public CommandBarUIAdapter(IWordCommandBarContainer container)
        {
            _container = Guard.ArgumentNotNull<IWordCommandBarContainer>(container);
        }

        protected override IWordCommandBar Add(IWordCommandBar uiElement)
        {
            _container.AddBar(uiElement);
            return uiElement;
        }

        protected override void Remove(IWordCommandBar uiElement)
        {
            throw new NotSupportedException("Удаление тулбаров не поддерживается");
        }

        private IWordCommandBarContainer _container;
    }
}
