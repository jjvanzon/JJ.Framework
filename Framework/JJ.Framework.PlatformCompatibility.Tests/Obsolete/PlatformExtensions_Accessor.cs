using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using JJ.Framework.Reflection;
using JJ.Framework.Reflection.Core;

// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    internal static class PlatformExtensions_Accessor
    {
        private static readonly AccessorCore _accessor
            = new AccessorCore(Type.GetType("JJ.Framework.PlatformCompatibility.Legacy.Obsolete.PlatformExtensions, " +
                                            "JJ.Framework.PlatformCompatibility.Legacy"));

        public static MemberTypes_PlatformSafe MemberType_PlatformSafe(MemberInfo memberInfo)
            => _accessor.Call(() => MemberType_PlatformSafe(memberInfo));

        public static Type GetInterface_PlatformSafe(Type type, string name)
            => _accessor.Call(() => GetInterface_PlatformSafe(type, name));

        public static void Save_PlatformSafe(XDocument doc, string fileName)
            => _accessor.Call(() => Save_PlatformSafe(doc, fileName));

        public static void Save_PlatformSafe(XElement element, string fileName)
            => _accessor.Call(() => Save_PlatformSafe(element, fileName));

        public static void Save_PlatformSafe(XElement element, Stream stream)
            => _accessor.Call(() => Save_PlatformSafe(element, stream));

        public static object GetValue_PlatformSafe(PropertyInfo propertyInfo, object obj, params object[] parameters)
            => _accessor.Call(() => GetValue_PlatformSafe(propertyInfo, obj, parameters));
    }
}
