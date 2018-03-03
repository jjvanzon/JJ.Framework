using System;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Common
{
	/// <summary>
	/// Static classes cannot get extension membrers.
	/// Instead we have the DoubleHelper class for extra static members.
	/// </summary>
	public static class DoubleHelper
	{
		/// <summary> Returns true if the value is NaN, PositiveInfinity or NegativeInfinity. </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSpecialValue(double value) => double.IsNaN(value) || double.IsInfinity(value);

		[Obsolete("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.", true)]
		public static bool TryParse(string s, IFormatProvider provider, out double result) 
			=> throw new NotImplementedException("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.");

		[Obsolete("Use JJ.Framework.Conversion.DoubleParser.ParseNullable instead.", true)]
		public static double? ParseNullable(string input) 
			=> throw new NotImplementedException("Use JJ.Framework.Conversion.DoubleParser.ParseNullable instead.");

		[Obsolete("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.", true)]
		public static bool TryParse(string input, out double? output) 
			=> throw new NotImplementedException("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.");
	}
}
