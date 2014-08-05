using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace JJ.Framework.PlatformCompatibility
{
    public static class PlatformSafeExtensions
    {
        /// <summary>
        /// Windows Phone / Unity compatibility:
        /// Don't switch on MemberInfo.MemberType. It produced a strange exception when deployed to Windows Phone using Unity:
        /// "Method not found: 'System.Reflection.MemberTypes".
        /// Use 'is PropertyInfo' and such or call this method instead.
        /// </summary>
        public static PlatformSafeMemberTypes MemberType_PlatformSafe(this MemberInfo memberInfo)
        {
            return PlatformHelper.PlatformSafe_MemberType(memberInfo);
        }

        /// <summary>
        /// iOS compatibility: PropertyInfo.GetValue in Mono on a generic type may cause JIT compilation, which is not supported by iOS.
        /// Use 'PropertyInfo.GetGetMethod().Invoke(object obj, params object[] parameters)' or call this method instead.
        /// </summary>
        public static object GetValue_PlatformSafe(this PropertyInfo propertyInfo, object obj, params object[] parameters)
        {
            return PlatformHelper.PlatformSafe_PropertyInfo_GetValue(propertyInfo, obj, parameters);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// Type.GetInterface(string name) is not supported on Windows Phone 8.
        /// Use the overload 'Type.GetInterface(string name, bool ingoreCase)' or call this method instead.
        /// </summary>
        public static Type GetInterface_PlatformSafe(this Type type, string name)
        {
            return PlatformHelper.PlatformSafe_Type_GetInterface(type, name);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XDocument.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// Beware that this overload simply saves the root node
        /// and does not the features unique to XDocument.
        /// </summary>
        public static void Save_PlatformSafe(this XDocument doc, string fileName)
        {
            PlatformHelper.PlatformSafe_XDocument_Save(doc, fileName);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XElement.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void Save_PlatformSafe(this XElement element, string fileName)
        {
            PlatformHelper.PlatformSafe_XElement_Save(element, fileName);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XElement.Save(Stream) exists on Windows Phone 8, but not in .NET 3.5.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void Save_PlatformSafe(this XElement element, Stream stream)
        {
            PlatformHelper.PlatformSafe_XElement_Save(element, stream);
        }
    }
}
