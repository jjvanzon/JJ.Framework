using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.Xml
{
    internal static class ConversionHelper
    {
        public static object Convert(string value, Type type)
        {
            // TODO: Extend with other conversions.
            return System.Convert.ChangeType(value, type);
        }

        public static TValue Convert<TValue>(string value)
        {
            return (TValue)Convert(value, typeof(TValue));
        }
    }
}
