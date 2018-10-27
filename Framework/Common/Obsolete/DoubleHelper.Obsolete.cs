using System;
// ReSharper disable CheckNamespace

namespace JJ.Framework.Common
{
	/// <summary>
	/// Static classes cannot get extension members.
	/// Instead we have the DoubleHelper class for extra static members.
	/// </summary>
	public static partial class DoubleHelper
	{
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
