using System;
// ReSharper disable CheckNamespace

namespace JJ.Framework.Common
{
	public static partial class EnumHelper
	{
		[Obsolete("Use JJ.Framework.Conversion.EnumParser.Parse instead.", true)]
		public static TEnum Parse<TEnum>(string value)
			where TEnum : struct
			=> throw new NotSupportedException("Use JJ.Framework.Conversion.EnumParser.Parse instead.");
	}
}