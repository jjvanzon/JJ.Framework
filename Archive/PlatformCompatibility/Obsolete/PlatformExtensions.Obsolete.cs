using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility.Obsolete
{
    [Obsolete("Use PlatformHelper instead.", true)]
    public static class PlatformExtensions
    {
        [Obsolete("Use PlatformHelper instead.", true)]
        public static MemberTypes_PlatformSafe MemberType_PlatformSafe(this MemberInfo memberInfo) 
            => throw new NotSupportedException("Use PlatformHelper instead.");

        [Obsolete("Use PlatformHelper instead.", true)]
        public static Type GetInterface_PlatformSafe(this Type type, string name) 
            => throw new NotSupportedException("Use PlatformHelper instead.");

        [Obsolete("Use PlatformHelper instead.", true)]
        public static void Save_PlatformSafe(this XDocument doc, string fileName) 
            => throw new NotSupportedException("Use PlatformHelper instead.");

        [Obsolete("Use PlatformHelper instead.", true)]
        public static void Save_PlatformSafe(this XElement element, string fileName)
            => throw new NotSupportedException("Use PlatformHelper instead.");

        [Obsolete("Use PlatformHelper instead.", true)]
        public static void Save_PlatformSafe(this XElement element, Stream stream)
            => throw new NotSupportedException("Use PlatformHelper instead.");

        [Obsolete("Use PlatformHelper instead.", true)]
        public static object GetValue_PlatformSafe(this PropertyInfo propertyInfo, object obj, params object[] parameters)
            => throw new NotSupportedException("Use PlatformHelper instead.");
    }
}
