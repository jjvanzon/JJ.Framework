using System;
using JJ.Framework.Reflection;

// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common.Tests.Obsolete
{
    internal static class EnumHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(EnumHelper));

        public static TEnum Parse<TEnum>(string value)
        {
            Type[] parameterTypes = { typeof(string) };
            Type[] typeArguments = { typeof(TEnum) };
            return (TEnum)_accessor.InvokeMethod(nameof(Parse), new object[] { value }, parameterTypes, typeArguments);
        }
    }
}
