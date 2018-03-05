

using System;
using System.Globalization;
using JJ.Framework.Common;

namespace JJ.Framework.Conversion
{
	
		/// <summary>
		/// For instance making it easier to parse nullable Decimal.
		/// Static classes cannot get extension members.
		/// Otherwise these would have been extensions.
		/// Instead we have the DecimalParser class for extra static members.
		/// </summary>
		public static class DecimalParser
		{
			public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Number;

			/// <summary>
			/// If you want to use Decimal.TryParse with a format provider,
			/// then you are obliged to also pass NumberStyles.
			/// If you ever wonder what NumberStyles to pass,
			/// just call this method instead. It will mimic the default behavior of TryParse.
			/// </summary>
			public static bool TryParse(string s, IFormatProvider provider, out Decimal result)
				=> Decimal.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

			/// <summary> Parses a nullable Decimal. </summary>
			public static bool TryParse(string input, IFormatProvider provider, out Decimal? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

			/// <summary> Parses a nullable Decimal. </summary>
			public static bool TryParse(string input, NumberStyles style, out Decimal? output)
				=> TryParse(input, style, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Decimal. </summary>
			public static bool TryParse(string input, out Decimal? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Decimal. </summary>
			public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out Decimal? output)
			{
				output = default;

				if (string.IsNullOrWhiteSpace(input))
				{
					return true;
				}

				bool result = Decimal.TryParse(input, style, provider, out Decimal temp);
				if (!result)
				{
					return false;
				}

				output = temp;

				return true;
			}

			public static Decimal? ParseNullable(string input)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo);

			public static Decimal? ParseNullable(string input, NumberStyles style)
				=> ParseNullable(input, style, NumberFormatInfo.CurrentInfo);

			public static Decimal? ParseNullable(string input, IFormatProvider provider)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, provider);

			public static Decimal? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return null;
				}

				return Decimal.Parse(input, style, provider);
			}
		}

	
		/// <summary>
		/// For instance making it easier to parse nullable Double.
		/// Static classes cannot get extension members.
		/// Otherwise these would have been extensions.
		/// Instead we have the DoubleParser class for extra static members.
		/// </summary>
		public static class DoubleParser
		{
			public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Any;

			/// <summary>
			/// If you want to use Double.TryParse with a format provider,
			/// then you are obliged to also pass NumberStyles.
			/// If you ever wonder what NumberStyles to pass,
			/// just call this method instead. It will mimic the default behavior of TryParse.
			/// </summary>
			public static bool TryParse(string s, IFormatProvider provider, out Double result)
				=> Double.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

			/// <summary> Parses a nullable Double. </summary>
			public static bool TryParse(string input, IFormatProvider provider, out Double? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

			/// <summary> Parses a nullable Double. </summary>
			public static bool TryParse(string input, NumberStyles style, out Double? output)
				=> TryParse(input, style, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Double. </summary>
			public static bool TryParse(string input, out Double? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Double. </summary>
			public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out Double? output)
			{
				output = default;

				if (string.IsNullOrWhiteSpace(input))
				{
					return true;
				}

				bool result = Double.TryParse(input, style, provider, out Double temp);
				if (!result)
				{
					return false;
				}

				output = temp;

				return true;
			}

			public static Double? ParseNullable(string input)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo);

			public static Double? ParseNullable(string input, NumberStyles style)
				=> ParseNullable(input, style, NumberFormatInfo.CurrentInfo);

			public static Double? ParseNullable(string input, IFormatProvider provider)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, provider);

			public static Double? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return null;
				}

				return Double.Parse(input, style, provider);
			}
		}

	
		/// <summary>
		/// For instance making it easier to parse nullable Int16.
		/// Static classes cannot get extension members.
		/// Otherwise these would have been extensions.
		/// Instead we have the Int16Parser class for extra static members.
		/// </summary>
		public static class Int16Parser
		{
			public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Integer;

			/// <summary>
			/// If you want to use Int16.TryParse with a format provider,
			/// then you are obliged to also pass NumberStyles.
			/// If you ever wonder what NumberStyles to pass,
			/// just call this method instead. It will mimic the default behavior of TryParse.
			/// </summary>
			public static bool TryParse(string s, IFormatProvider provider, out Int16 result)
				=> Int16.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

			/// <summary> Parses a nullable Int16. </summary>
			public static bool TryParse(string input, IFormatProvider provider, out Int16? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

			/// <summary> Parses a nullable Int16. </summary>
			public static bool TryParse(string input, NumberStyles style, out Int16? output)
				=> TryParse(input, style, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Int16. </summary>
			public static bool TryParse(string input, out Int16? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Int16. </summary>
			public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out Int16? output)
			{
				output = default;

				if (string.IsNullOrWhiteSpace(input))
				{
					return true;
				}

				bool result = Int16.TryParse(input, style, provider, out Int16 temp);
				if (!result)
				{
					return false;
				}

				output = temp;

				return true;
			}

			public static Int16? ParseNullable(string input)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo);

			public static Int16? ParseNullable(string input, NumberStyles style)
				=> ParseNullable(input, style, NumberFormatInfo.CurrentInfo);

			public static Int16? ParseNullable(string input, IFormatProvider provider)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, provider);

			public static Int16? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return null;
				}

				return Int16.Parse(input, style, provider);
			}
		}

	
		/// <summary>
		/// For instance making it easier to parse nullable Int32.
		/// Static classes cannot get extension members.
		/// Otherwise these would have been extensions.
		/// Instead we have the Int32Parser class for extra static members.
		/// </summary>
		public static class Int32Parser
		{
			public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Integer;

			/// <summary>
			/// If you want to use Int32.TryParse with a format provider,
			/// then you are obliged to also pass NumberStyles.
			/// If you ever wonder what NumberStyles to pass,
			/// just call this method instead. It will mimic the default behavior of TryParse.
			/// </summary>
			public static bool TryParse(string s, IFormatProvider provider, out Int32 result)
				=> Int32.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

			/// <summary> Parses a nullable Int32. </summary>
			public static bool TryParse(string input, IFormatProvider provider, out Int32? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

			/// <summary> Parses a nullable Int32. </summary>
			public static bool TryParse(string input, NumberStyles style, out Int32? output)
				=> TryParse(input, style, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Int32. </summary>
			public static bool TryParse(string input, out Int32? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Int32. </summary>
			public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out Int32? output)
			{
				output = default;

				if (string.IsNullOrWhiteSpace(input))
				{
					return true;
				}

				bool result = Int32.TryParse(input, style, provider, out Int32 temp);
				if (!result)
				{
					return false;
				}

				output = temp;

				return true;
			}

			public static Int32? ParseNullable(string input)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo);

			public static Int32? ParseNullable(string input, NumberStyles style)
				=> ParseNullable(input, style, NumberFormatInfo.CurrentInfo);

			public static Int32? ParseNullable(string input, IFormatProvider provider)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, provider);

			public static Int32? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return null;
				}

				return Int32.Parse(input, style, provider);
			}
		}

	
		/// <summary>
		/// For instance making it easier to parse nullable Int64.
		/// Static classes cannot get extension members.
		/// Otherwise these would have been extensions.
		/// Instead we have the Int64Parser class for extra static members.
		/// </summary>
		public static class Int64Parser
		{
			public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Integer;

			/// <summary>
			/// If you want to use Int64.TryParse with a format provider,
			/// then you are obliged to also pass NumberStyles.
			/// If you ever wonder what NumberStyles to pass,
			/// just call this method instead. It will mimic the default behavior of TryParse.
			/// </summary>
			public static bool TryParse(string s, IFormatProvider provider, out Int64 result)
				=> Int64.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

			/// <summary> Parses a nullable Int64. </summary>
			public static bool TryParse(string input, IFormatProvider provider, out Int64? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

			/// <summary> Parses a nullable Int64. </summary>
			public static bool TryParse(string input, NumberStyles style, out Int64? output)
				=> TryParse(input, style, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Int64. </summary>
			public static bool TryParse(string input, out Int64? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Int64. </summary>
			public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out Int64? output)
			{
				output = default;

				if (string.IsNullOrWhiteSpace(input))
				{
					return true;
				}

				bool result = Int64.TryParse(input, style, provider, out Int64 temp);
				if (!result)
				{
					return false;
				}

				output = temp;

				return true;
			}

			public static Int64? ParseNullable(string input)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo);

			public static Int64? ParseNullable(string input, NumberStyles style)
				=> ParseNullable(input, style, NumberFormatInfo.CurrentInfo);

			public static Int64? ParseNullable(string input, IFormatProvider provider)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, provider);

			public static Int64? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return null;
				}

				return Int64.Parse(input, style, provider);
			}
		}

	
		/// <summary>
		/// For instance making it easier to parse nullable Single.
		/// Static classes cannot get extension members.
		/// Otherwise these would have been extensions.
		/// Instead we have the SingleParser class for extra static members.
		/// </summary>
		public static class SingleParser
		{
			public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Any;

			/// <summary>
			/// If you want to use Single.TryParse with a format provider,
			/// then you are obliged to also pass NumberStyles.
			/// If you ever wonder what NumberStyles to pass,
			/// just call this method instead. It will mimic the default behavior of TryParse.
			/// </summary>
			public static bool TryParse(string s, IFormatProvider provider, out Single result)
				=> Single.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

			/// <summary> Parses a nullable Single. </summary>
			public static bool TryParse(string input, IFormatProvider provider, out Single? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

			/// <summary> Parses a nullable Single. </summary>
			public static bool TryParse(string input, NumberStyles style, out Single? output)
				=> TryParse(input, style, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Single. </summary>
			public static bool TryParse(string input, out Single? output)
				=> TryParse(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo, out output);

			/// <summary> Parses a nullable Single. </summary>
			public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out Single? output)
			{
				output = default;

				if (string.IsNullOrWhiteSpace(input))
				{
					return true;
				}

				bool result = Single.TryParse(input, style, provider, out Single temp);
				if (!result)
				{
					return false;
				}

				output = temp;

				return true;
			}

			public static Single? ParseNullable(string input)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, NumberFormatInfo.CurrentInfo);

			public static Single? ParseNullable(string input, NumberStyles style)
				=> ParseNullable(input, style, NumberFormatInfo.CurrentInfo);

			public static Single? ParseNullable(string input, IFormatProvider provider)
				=> ParseNullable(input, DEFAULT_NUMBER_STYLES, provider);

			public static Single? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					return null;
				}

				return Single.Parse(input, style, provider);
			}
		}

	
}