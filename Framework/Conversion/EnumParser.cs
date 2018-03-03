using System;

namespace JJ.Framework.Conversion
{
	public static class EnumParser
	{
		public static TEnum Parse<TEnum>(string value)
			where TEnum : struct => (TEnum)Enum.Parse(typeof(TEnum), value);
	}
}