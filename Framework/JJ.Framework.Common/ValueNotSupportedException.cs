using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common.Legacy 
{
    /// <inheritdoc cref="_valuenotsupportedexception" />
    public class ValueNotSupportedException : Exception
    {
        private const string MESSAGE = "{0} value: '{1}' is not supported.";

        /// <inheritdoc cref="_valuenotsupportedexception" />
        public ValueNotSupportedException(object value)
            : base(String.Format(MESSAGE, value?.GetType().Name, value))
        { }
    }
}
