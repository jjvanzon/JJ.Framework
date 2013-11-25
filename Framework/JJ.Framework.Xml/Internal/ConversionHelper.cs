using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Xml.Internal
{
    internal static class ConversionHelper
    {
        public static TValue ConvertValue<TValue>(object input)
        {
            TValue value = (TValue)ConvertValue(input, typeof(TValue));
            return value;
        }

        public static object ConvertValue(object input, Type type)
        {
            return Convert.ChangeType(input, type);
        }
    }
}
