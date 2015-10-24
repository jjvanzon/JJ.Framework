using System;

namespace JJ.Framework.Common
{
    public class InvalidValueException : Exception
    {
        private const string MESSAGE = "Invalid {0} value: '{1}'.";

        // TODO:
        // Warning CA1062  In externally visible method 'InvalidValueException.InvalidValueException(object)', validate parameter 'value' before using it.
        public InvalidValueException(object value)
            : base(String.Format(MESSAGE, value.GetType().Name, value))
        { }
    }
}
