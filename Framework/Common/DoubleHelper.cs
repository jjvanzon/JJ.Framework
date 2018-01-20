using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Common
{
	/// <summary>
	/// Static classes cannot get extension membrers.
	/// Instead we have the DoubleHelper class for extra static members.
	/// </summary>
	public static class DoubleHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryParse(string s, IFormatProvider provider, out double result)
		{
			return double.TryParse(s, NumberStyles.Any, provider, out result);
		}

		/// <summary> Returns true if the value is NaN, PositiveInfinity or NegativeInfinity. </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSpecialValue(double value)
		{
			return double.IsNaN(value) || double.IsInfinity(value);
		}

		public static double? ParseNullable(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			return double.Parse(input);
		}

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
	}
}
