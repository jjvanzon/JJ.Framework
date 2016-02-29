using System;

namespace JJ.Framework.Common.Exceptions
{
    public class InvalidValueException : Exception
    {
        private const string MESSAGE = "Invalid {0} value: '{1}'.";

        private string _message;

        public override string Message
        {
            get { return _message; }
        }

        public InvalidValueException(object value)
        {
            if (value == null) throw new ArgumentNullException("value");

            _message = String.Format(MESSAGE, value.GetType().Name, value);
        }
    }
}
