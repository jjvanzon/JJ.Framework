using System;

namespace JJ.Framework.Common.Exceptions
{
    public class ValueNotSupportedException : Exception
    {
        private const string MESSAGE = "{0} value: '{1}' is not supported.";

        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public ValueNotSupportedException(object value)
        {
            if (value == null)
            {
                _message = String.Format(MESSAGE, "<null>", "<null>");
            }
            else
            {
                _message = String.Format(MESSAGE, value.GetType(), value);
            }
        }
    }
}
