using System;

namespace JJ.Framework.Configuration
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
