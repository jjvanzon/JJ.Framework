using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Configuration
{
    internal static class ConfigurationHelper
    {
        public static TValue ConvertValue<TValue>(object str)
        {
            TValue value = (TValue)Convert.ChangeType(str, typeof(TValue));
            return value;
        }
    }
}
