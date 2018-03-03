//using System;
//using System.Globalization;
//using JJ.Framework.Common;

//namespace JJ.Framework.Conversion
//{
//	/// <summary>
//	/// For instance making it easier to parse nullable ints.
//	/// Static classes cannot get extension members.
//	/// Otherwise these would have been extensions.
//	/// Instead we have the Int32Parser class for extra static members.
//	/// </summary>
//	public static class Int32Parser
//	{
//		public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Integer;

//		private static CultureInfo GetCurrentFormatProvider() => CultureHelper.GetCurrentCulture();

//		/// <summary>
//		/// If you want to use Int32.TryParse with a format provider,
//		/// then you are obliged to also pass NumberStyles.
//		/// If you ever wonder what NumberStyles to pass,
//		/// just call this method instead. It will mimic the default behavior of TryParse.
//		/// </summary>
//		public static bool TryParse(string s, IFormatProvider provider, out int result)
//			=> int.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

//		/// <summary> Parses a nullable int. </summary>
//		public static bool TryParse(string input, IFormatProvider provider, out int? output)
//			=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

//		/// <summary> Parses a nullable int. </summary>
//		public static bool TryParse(string input, NumberStyles style, out int? output)
//			=> TryParse(input, style, GetCurrentFormatProvider(), out output);

//		/// <summary> Parses a nullable int. </summary>
//		public static bool TryParse(string input, out int? output)
//		{
//			output = default;

//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return true;
//			}

//			bool result = int.TryParse(input, out int temp);
//			if (!result)
//			{
//				return false;
//			}

//			output = temp;

//			return true;
//		}

//		/// <summary> Parses a nullable int. </summary>
//		public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out int? output)
//		{
//			output = default;

//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return true;
//			}

//			bool result = int.TryParse(input, style, provider, out int temp);
//			if (!result)
//			{
//				return false;
//			}

//			output = temp;

//			return true;
//		}

//		public static int? ParseNullable(string input)
//		{
//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return null;
//			}

//			return int.Parse(input);
//		}

//		public static int? ParseNullable(string input, NumberStyles style)
//		{
//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return null;
//			}

//			return int.Parse(input, style, GetCurrentFormatProvider());
//		}

//		public static int? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
//		{
//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return null;
//			}

//			return int.Parse(input, style, provider);
//		}

//		public static int? ParseNullable(string input, IFormatProvider provider)
//		{
//			if (string.IsNullOrWhiteSpace(input))
//			{
//				return null;
//			}

//			return int.Parse(input, DEFAULT_NUMBER_STYLES, provider);
//		}
//	}
//}