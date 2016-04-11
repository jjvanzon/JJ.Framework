using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Common
{
    public static class EnumHelper
    {
        public static TEnum Parse<TEnum>(string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }

        public static IList<TEnum> GetValues<TEnum>()
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }
}
