using System;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.Framework.Conversion
{
	/// <summary> Makes it easier to convert simple types. </summary>
	public static class SimpleTypeConverter
	{
		/// <summary>
		/// One method to parse numeric types, their signed and unsigned variations, DateTime, TimeSpan, Guid and Enum types, IntPtr, UIntPtr 
		/// and their nullable variations. Those often require different types of conversions. This method just takes care of it.
		/// </summary>
		public static T ParseValue<T>(string input) => ParseValue<T>(input, CultureHelper.GetCurrentCulture());

		/// <summary>
		/// One method to parse numeric types, their signed and unsigned variations, DateTime, TimeSpan, Guid and Enum types, IntPtr, UIntPtr 
		/// and their nullable variations. Those often require different types of conversions. This method just takes care of it.
		/// </summary>
		public static T ParseValue<T>(string input, IFormatProvider formatProvider) => (T)ParseValue(input, typeof(T), formatProvider);

		/// <summary>
		/// One method to parse numeric types, their signed and unsigned variations, DateTime, TimeSpan, Guid and Enum types, IntPtr, UIntPtr 
		/// and their nullable variations. Those often require different types of conversions. This method just takes care of it.
		/// </summary>
		public static object ParseValue(string input, Type type) => ParseValue(input, type, CultureHelper.GetCurrentCulture());

		/// <summary>
		/// One method to parse numeric types, their signed and unsigned variations, DateTime, TimeSpan, Guid and Enum types, IntPtr, UIntPtr 
		/// and their nullable variations. Those often require different types of conversions. This method just takes care of it.
		/// </summary>
		public static object ParseValue(string input, Type type, IFormatProvider formatProvider)
		{
			if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

			if (type.IsNullableType())
			{
				if (string.IsNullOrEmpty(input))
				{
					return null;
				}

				type = type.GetUnderlyingNullableTypeFast();
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

		/// <summary> Makes it easier to convert nullables along with non-nullables. </summary>
		public static T ConvertValue<T>(object input)
		{
			var value = (T)ConvertValue(input, typeof(T));
			return value;
		}

		/// <summary> Makes it easier to convert nullables along with non-nullables. </summary>
		public static object ConvertValue(object input, Type type)
		{
			if (input == null)
			{
				return null;
			}

			if (type.IsNullableType())
			{
				type = type.GetUnderlyingNullableTypeFast();
			}

			return Convert.ChangeType(input, type);
		}
	}
}