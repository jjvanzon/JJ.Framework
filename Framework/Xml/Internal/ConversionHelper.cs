using JJ.Framework.Reflection;
using System;
using System.Globalization;
using JJ.Framework.PlatformCompatibility;

namespace JJ.Framework.Xml.Internal
{
    internal static class ConversionHelper
    {
        private static CultureInfo _culture = CultureInfo_PlatformSafe.GetCultureInfo("en-US");

        public static object ConvertValue(string input, Type type)
        {
            if (type.IsNullableType())
            {
                if (String.IsNullOrEmpty(input))
                {
                    return null;
                }

                type = type.GetUnderlyingNullableType();
            }

            if (type.IsEnum)
            {
                return Enum.Parse(type, input);
            }

            if (type == typeof(TimeSpan))
            {
                return TimeSpan.Parse(input);
            }

            if (type == typeof(Guid))
            {
                return new Guid(input);
            }

            if (type == typeof(IntPtr))
            {
                int number = Int32.Parse(input);
                return new IntPtr(number);
            }

            if (type == typeof(UIntPtr))
            {
                uint number = UInt32.Parse(input);
                return new UIntPtr(number);
            }

            return Convert.ChangeType(input, type, _culture);
        }
    }
}
