using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Common
{
    public class InvalidEnumValueException : Exception
    {
        private const string MESSAGE = "Invalid {0} enum value: '{1}'.";

        public InvalidEnumValueException(object value)
            : base(String.Format(MESSAGE, value.GetType(), value))
        { }
    }
}
