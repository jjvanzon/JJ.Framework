using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

// ReSharper disable CheckNamespace
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility
{
    public static partial class PlatformHelper
    {
        [Obsolete("Use MemberType_PlatformSafe instead.", true)]
        public static MemberTypes_PlatformSafe MemberInfo_MemberType_PlatformSafe(MemberInfo memberInfo)
            => throw new NotSupportedException("Use MemberType_PlatformSafe instead.");

        [Obsolete("Use GetInterface_PlatformSafe instead.", true)]
        public static Type Type_GetInterface_PlatformSafe(Type type, string name)
            => throw new NotSupportedException("Use GetInterface_PlatformSafe instead.");

        [Obsolete("Use Save_PlatformSafe instead.", true)]
        public static void XDocument_Save_PlatformSafe(XDocument doc, string fileName)
            => throw new NotSupportedException("Use Save_PlatformSafe instead.");

        [Obsolete("Use Save_PlatformSafe instead.", true)]
        public static void XElement_Save_PlatformSafe(XElement element, string fileName)
            => throw new NotSupportedException("Use Save_PlatformSafe instead.");

        [Obsolete("Use Save_PlatformSafe instead.", true)]
        public static void XElement_Save_PlatformSafe(XElement element, Stream stream)
            => throw new NotSupportedException("Use Save_PlatformSafe instead.");

        [Obsolete("Use GetValue_PlatformSafe instead.", true)]
        public static object PropertyInfo_GetValue_PlatformSafe(PropertyInfo propertyInfo, object obj, params object[] parameters)
            => throw new NotSupportedException("Use GetValue_PlatformSafe instead.");
    }
}
