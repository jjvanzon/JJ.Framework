using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Common
{
    public class ValueNotSupportedException : Exception
    {
        private const string MESSAGE = "{0} value: '{1}' is not supported.";

        public ValueNotSupportedException(object value)
            : base(String.Format(MESSAGE, value.GetType(), value))
        { }
    }
}
