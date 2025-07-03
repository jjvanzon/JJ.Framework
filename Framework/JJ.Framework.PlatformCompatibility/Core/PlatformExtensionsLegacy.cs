using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace JJ.Framework.PlatformCompatibility.Core
{
    /// <inheritdoc cref="_platformextensions"/>
    public static class PlatformExtensionsLegacy
    {
        /// <inheritdoc cref="_membertype" />
        public static MemberTypes_PlatformSafe MemberType_PlatformSafe(this MemberInfo memberInfo)
        {
            return PlatformHelper.MemberInfo_MemberType_PlatformSafe(memberInfo);
        }

        /// <inheritdoc cref="_getinterface" />
        public static Type GetInterface_PlatformSafe(this Type type, string name)
        {
            return PlatformHelper.Type_GetInterface_PlatformSafe(type, name);
        }

        /// <inheritdoc cref="_xdocumentsave" />
        public static void Save_PlatformSafe(this XDocument doc, string fileName)
        {
            PlatformHelper.XDocument_Save_PlatformSafe(doc, fileName);
        }

        /// <inheritdoc cref="_xelementsave" />
        public static void Save_PlatformSafe(this XElement element, string fileName)
        {
            PlatformHelper.XElement_Save_PlatformSafe(element, fileName);
        }

        /// <inheritdoc cref="_xelementsave" />
        public static void Save_PlatformSafe(this XElement element, Stream stream)
        {
            PlatformHelper.XElement_Save_PlatformSafe(element, stream);
        }

        /// <inheritdoc cref="_getcustomattribute" />
        public static TAttribute GetCustomAttribute_PlatformSupport<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return PlatformHelperLegacy.PropertyInfo_GetCustomAttribute_PlatformSupport<TAttribute>(propertyInfo);
        }

        /// <inheritdoc cref="_setvalue" />
        public static void SetValue_PlatformSupport(this PropertyInfo propertyInfo, object obj, object value)
        {
            PlatformHelperLegacy.PropertyInfo_SetValue_PlatformSupport(propertyInfo, obj, value);
        }

        /// <inheritdoc cref="_getvalue" />
        public static object GetValue_PlatformSafe(this PropertyInfo propertyInfo, object obj, params object[] parameters)
        {
            // TODO: Is the original GetValue not without params. Why make a substitute different than what it substitutes?
            return PlatformHelper.PropertyInfo_GetValue_PlatformSafe(propertyInfo, obj, parameters);
        }

    }
}
