using System;

namespace JJ.Framework.Common
{
    public class ValueNotSupportedException : Exception
    {
        private const string MESSAGE = "{0} value: '{1}' is not supported.";

        // TODO:
        // Warning CA1062  In externally visible method 'ValueNotSupportedException.ValueNotSupportedException(object)', validate parameter 'value' before using it.

        public ValueNotSupportedException(object value)
            : base(String.Format(MESSAGE, value.GetType(), value))
        { }
    }
}
