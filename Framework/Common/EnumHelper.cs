using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Framework.Common
{
	[PublicAPI]
	public static class EnumHelper
	{
		public static IList<TEnum> GetValues<TEnum>()
			where TEnum : struct 
			=> (TEnum[])Enum.GetValues(typeof(TEnum));

		public static bool IsValidEnum<TEnum>(TEnum enumMember)
			where TEnum : struct 
			=> GetValues<TEnum>().Contains(enumMember);

		[Obsolete("Use JJ.Framework.Conversion.EnumParser.Parse instead.", true)]
		public static TEnum Parse<TEnum>(string value)
			where TEnum : struct
			=> throw new NotImplementedException("Use JJ.Framework.Conversion.EnumParser.Parse instead.");
	}
}