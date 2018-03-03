// NOTE: This code file is used as a base for the code generated in NumericParsers.tt.

using System;
using System.Globalization;
using JJ.Framework.Common;

namespace JJ.Framework.Conversion
{
	/// <summary>
	/// For instance making it easier to parse nullable doubles.
	/// Static classes cannot get extension members.
	/// Otherwise these would have been extensions.
	/// Instead we have the DoubleParser class for extra static members.
	/// </summary>
	public static class DoubleParser
	{
		public const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.Any;

		private static CultureInfo GetCurrentFormatProvider() => CultureHelper.GetCurrentCulture();

		/// <summary>
		/// If you want to use Double.TryParse with a format provider,
		/// then you are obliged to also pass NumberStyles.
		/// If you ever wonder what NumberStyles to pass,
		/// just call this method instead. It will mimic the default behavior of TryParse.
		/// </summary>
		public static bool TryParse(string s, IFormatProvider provider, out double result)
			=> double.TryParse(s, DEFAULT_NUMBER_STYLES, provider, out result);

		/// <summary> Parses a nullable double. </summary>
		public static bool TryParse(string input, IFormatProvider provider, out double? output)
			=> TryParse(input, DEFAULT_NUMBER_STYLES, provider, out output);

		/// <summary> Parses a nullable double. </summary>
		public static bool TryParse(string input, NumberStyles style, out double? output)
			=> TryParse(input, style, GetCurrentFormatProvider(), out output);

		/// <summary> Parses a nullable double. </summary>
		public static bool TryParse(string input, out double? output)
		{
			output = default;

			if (string.IsNullOrWhiteSpace(input))
			{
				return true;
			}

			bool result = double.TryParse(input, out double temp);
			if (!result)
			{
				return false;
			}

			output = temp;

			return true;
		}

		/// <summary> Parses a nullable double. </summary>
		public static bool TryParse(string input, NumberStyles style, IFormatProvider provider, out double? output)
		{
			output = default;

			if (string.IsNullOrWhiteSpace(input))
			{
				return true;
			}

			bool result = double.TryParse(input, style, provider, out double temp);
			if (!result)
			{
				return false;
			}

			output = temp;

			return true;
		}

		public static double? ParseNullable(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			return double.Parse(input);
		}

		public static double? ParseNullable(string input, NumberStyles style)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			return double.Parse(input, style, GetCurrentFormatProvider());
		}

		public static double? ParseNullable(string input, NumberStyles style, IFormatProvider provider)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			return double.Parse(input, style, provider);
		}

		public static double? ParseNullable(string input, IFormatProvider provider)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			return double.Parse(input, DEFAULT_NUMBER_STYLES, provider);
		}
	}
}