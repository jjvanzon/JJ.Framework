//using JJ.Framework.Reflection;
//using System;
//using System.Globalization;

//namespace JJ.Framework.Xml.Internal
//{
//    internal static class ConversionHelper
//    {
//        private static readonly CultureInfo _defaultFormatProvider = new CultureInfo("en-US");

//        public static TDest ParseValue<TDest>(string input) => ParseValue<TDest>(input, _defaultFormatProvider);

//        public static TDest ParseValue<TDest>(string input, IFormatProvider formatProvider)
//        {
//            return (TDest)ParseValue(input, typeof(TDest), formatProvider);
//        }

//        public static object ParseValue(string input, Type type) => ParseValue(input, type, _defaultFormatProvider);

//        public static object ParseValue(string input, Type type, IFormatProvider formatProvider)
//        {
//            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

//            if (type.IsNullableType())
//            {
//                if (string.IsNullOrEmpty(input))
//                {
//                    return null;
//                }

//                type = type.GetUnderlyingNullableType();
//            }

//            if (type.IsEnum)
//            {
//                return Enum.Parse(type, input);
//            }

//            if (type == typeof(TimeSpan))
//            {
//                return TimeSpan.Parse(input);
//            }

//            if (type == typeof(Guid))
//            {
//                return new Guid(input);
//            }

//            if (type == typeof(IntPtr))
//            {
//                int number = int.Parse(input);
//                return new IntPtr(number);
//            }

//            if (type == typeof(UIntPtr))
//            {
//                uint number = uint.Parse(input);
//                return new UIntPtr(number);
//            }

//            return Convert.ChangeType(input, type, formatProvider);
//        }
//    }
//}
