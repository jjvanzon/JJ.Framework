using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Framework.Common
{
    [PublicAPI]
    public static partial class EnumHelper
    {
        public static IList<TEnum> GetValues<TEnum>()
            where TEnum : struct 
            => (TEnum[])Enum.GetValues(typeof(TEnum));

        public static bool IsValidEnum<TEnum>(TEnum enumMember)
            where TEnum : struct 
            => GetValues<TEnum>().Contains(enumMember);


        public static bool IsValidEnum<TEnum>(object enumMember)
            where TEnum : struct
        {
            if (enumMember == null)
            {
                return false;
            }

            bool isDefined = Enum.IsDefined(typeof(TEnum), enumMember);
            return isDefined;
        }
    }
}