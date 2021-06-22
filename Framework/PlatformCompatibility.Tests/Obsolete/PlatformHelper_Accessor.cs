using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using JJ.Framework.Reflection;
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility.Tests.Obsolete
{
    internal static class PlatformHelper_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(PlatformHelper));

        public static MemberTypes_PlatformSafe MemberInfo_MemberType_PlatformSafe(MemberInfo memberInfo)
            => _accessor.InvokeMethod(() => MemberInfo_MemberType_PlatformSafe(memberInfo));

        public static Type Type_GetInterface_PlatformSafe(Type type, string name) 
            => _accessor.InvokeMethod(() => Type_GetInterface_PlatformSafe(type, name));

        public static void XDocument_Save_PlatformSafe(XDocument doc, string fileName)
            => _accessor.InvokeMethod(() => XDocument_Save_PlatformSafe(doc, fileName));

        public static void XElement_Save_PlatformSafe(XElement element, string fileName)
            => _accessor.InvokeMethod(() => XElement_Save_PlatformSafe(element, fileName));

        public static void XElement_Save_PlatformSafe(XElement element, Stream stream)
            => _accessor.InvokeMethod(() => XElement_Save_PlatformSafe(element, stream));

        public static object PropertyInfo_GetValue_PlatformSafe(PropertyInfo propertyInfo, object obj, params object[] parameters)
            => _accessor.InvokeMethod(() => PropertyInfo_GetValue_PlatformSafe(propertyInfo, obj, parameters));
    }
}
