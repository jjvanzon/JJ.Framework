using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using JJ.Framework.Reflection.Core;

// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    internal static class PlatformHelper_Accessor
    {
        private static readonly AccessorCore _accessor = new (typeof(JJ.Framework.PlatformCompatibility.Legacy.Obsolete.PlatformHelper));

        [Suppress("Aot", "IL3050", Justification = GenericMethod)]
        public static MemberTypes_PlatformSafe MemberInfo_MemberType_PlatformSafe(MemberInfo memberInfo)
            => _accessor.Call(() => MemberInfo_MemberType_PlatformSafe(memberInfo));

        [Suppress("Aot", "IL3050", Justification = GenericMethod)]
        public static CultureInfo CultureInfo_GetCultureInfo_PlatformSafe(string name)
            => _accessor.Call(() => CultureInfo_GetCultureInfo_PlatformSafe(name));

        [Suppress("Aot", "IL3050", Justification = GenericMethod)]
        public static Type Type_GetInterface_PlatformSafe(Type type, string name) 
            => _accessor.Call(() => Type_GetInterface_PlatformSafe(type, name));

        [Suppress("Aot", "IL3050", Justification = GenericMethod)]
        public static void XDocument_Save_PlatformSafe(XDocument doc, string fileName)
            => _accessor.Call(() => XDocument_Save_PlatformSafe(doc, fileName));

        [Suppress("Aot", "IL3050", Justification = GenericMethod)]
        public static void XElement_Save_PlatformSafe(XElement element, string fileName)
            => _accessor.Call(() => XElement_Save_PlatformSafe(element, fileName));

        [Suppress("Aot", "IL3050", Justification = GenericMethod)]
        public static void XElement_Save_PlatformSafe(XElement element, Stream stream)
            => _accessor.Call(() => XElement_Save_PlatformSafe(element, stream));

        [Suppress("Aot", "IL3050", Justification = GenericMethod)]
        public static object PropertyInfo_GetValue_PlatformSafe(PropertyInfo propertyInfo, object obj, params object[] parameters)
            => _accessor.Call(() => PropertyInfo_GetValue_PlatformSafe(propertyInfo, obj, parameters));
    }
}
