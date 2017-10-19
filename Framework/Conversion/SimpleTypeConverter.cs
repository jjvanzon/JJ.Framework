using System;
using System.Globalization;
using JJ.Framework.Reflection;

namespace JJ.Framework.Conversion
{
    public static class SimpleTypeConverter
    {
        private static readonly CultureInfo _defaultFormatProvider = new CultureInfo("en-US");

        public static T ParseValue<T>(string input) => ParseValue<T>(input, _defaultFormatProvider);

        public static T ParseValue<T>(string input, IFormatProvider formatProvider)
        {
            return (T)ParseValue(input, typeof(T), formatProvider);
        }
        
        public static object ParseValue(string input, Type type) => ParseValue(input, type, _defaultFormatProvider);

        public static object ParseValue(string input, Type type, IFormatProvider formatProvider)
        {
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            if (type.IsNullableType())
            {
                if (string.IsNullOrEmpty(input))
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
                int number = int.Parse(input);
                return new IntPtr(number);
            }

            if (type == typeof(UIntPtr))
            {
                uint number = uint.Parse(input);
                return new UIntPtr(number);
            }

            return Convert.ChangeType(input, type, formatProvider);
        }

        public static T ConvertValue<T>(object input)
        {
            T value = (T)ConvertValue(input, typeof(T));
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
