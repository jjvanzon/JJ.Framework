using System;
using System.Globalization;

namespace JJ.Framework.Common
{
	[Obsolete("Use JJ.Framework.Conversion.Int32Parser instead.", true)]
	public static class Int32Helper
	{
		public static bool TryParse(string s, IFormatProvider provider, out int result)
		{
			return int.TryParse(s, NumberStyles.Integer, provider, out result);
		}

		public static int? ParseNullable(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}

			return int.Parse(input);
		}

		public static bool TryParse(string input, out int? output)
		{
			output = default;

			if (string.IsNullOrWhiteSpace(input))
			{
				return true;
			}

			bool result = int.TryParse(input, out int temp);
			if (!result)
			{
				return false;
			}

			output = temp;

			return true;
		}
	}
}