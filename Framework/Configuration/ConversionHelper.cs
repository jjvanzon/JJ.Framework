using System;
using JJ.Framework.Reflection;

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
            if (input == null)
            {
                return null;
            }

            if (type.IsNullableType())
            {
                type = type.GetUnderlyingNullableType();
            }

            return Convert.ChangeType(input, type);
        }
    }
}
