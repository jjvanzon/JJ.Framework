using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public class InvalidValueException : Exception
    {
        private const string MESSAGE = "Invalid {0} value: '{1}'.";

        public InvalidValueException(object value)
            : base(String.Format(MESSAGE, value.GetType(), value))
        { }
    }
}
