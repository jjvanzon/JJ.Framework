using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common.Legacy 
{
    /// <inheritdoc cref="_invalidvalueexception" />
    public class InvalidValueException : Exception
    {
        private const string MESSAGE = "Invalid {0} value: '{1}'.";

        /// <inheritdoc cref="_invalidvalueexception" />
        public InvalidValueException(object value)
            : base(String.Format(MESSAGE, value?.GetType().Name, value))
        { }
    }
}
