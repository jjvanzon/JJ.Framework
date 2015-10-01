using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Common
{
    public static class EnumHelper
    {
        public static TEnum Parse<TEnum>(string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }
}
