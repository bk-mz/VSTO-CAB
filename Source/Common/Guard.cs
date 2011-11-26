using System;
using System.Collections.Generic;
using System.Text;

namespace WordCAB
{
    public class Guard
    {
        public static T ArgumentNotNull<T>(T value)
        {
            return (T)ArgumentNotNull(value, typeof(T).ToString());
        }

        public static object ArgumentNotNull(object value)
        {
            return ArgumentNotNull(value, "value");
        }

        public static object ArgumentNotNull(object value, string message)
        {
            if ( value == null )
                throw new ArgumentException(message);
            return value;
        }

        public static T Cast<T>(object value, string message)
        {
            Guard.ArgumentNotNull(value, message);
            return ( T )value;
        }
    }
}
