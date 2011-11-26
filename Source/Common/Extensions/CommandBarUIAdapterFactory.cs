using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.UIElements;
using WordCAB.Common.Controls;

namespace WordCAB.Common.Extensions
{
    public class CommandBarUIAdapterFactory : IUIElementAdapterFactory
    {
        public IUIElementAdapter GetAdapter(object uiElement)
        {
            if ( uiElement is IWordCommandBarContainer )
                return new CommandBarUIAdapter(( IWordCommandBarContainer )uiElement);
            if ( uiElement is IWordCommandBar )
                return new CommandBarButtonUIAdapter(( IWordCommandBar )uiElement);

            throw new ArgumentException("uiElement");
        }

        public bool Supports(object uiElement)
        {
            return ( uiElement is IWordCommandBarContainer ) || ( uiElement is IWordCommandBar );
        }
    }
}
