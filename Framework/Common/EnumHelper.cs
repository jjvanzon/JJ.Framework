using System;
using System.Collections;
using System.Collections.Generic;

namespace JJ.Framework.Common
{
    public static class EnumHelper
    {
        public static TEnum Parse<TEnum>(string value)
            where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }

        public static IList<TEnum> GetValues<TEnum>()
            where TEnum : struct
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }

        public static bool IsValidEnum<TEnum>(TEnum enumMember)
            where TEnum : struct
        {
            return GetValues<TEnum>().Contains(enumMember);
        }
    }
}
