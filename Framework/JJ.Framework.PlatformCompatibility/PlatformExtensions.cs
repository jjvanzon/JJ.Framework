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
    public static class PlatformExtensions
    {
        /// <summary>
        /// Windows Phone / Unity compatibility:
        /// Don't switch on MemberInfo.MemberType. It produced a strange exception when deployed to Windows Phone using Unity:
        /// "Method not found: 'System.Reflection.MemberTypes".
        /// Use 'is PropertyInfo' and such or call this method instead.
        /// </summary>
        public static MemberTypes_PlatformSafe MemberType_PlatformSafe(this MemberInfo memberInfo)
        {
            return PlatformHelper.MemberInfo_MemberType_PlatformSafe(memberInfo);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// Type.GetInterface(string name) is not supported on Windows Phone 8.
        /// Use the overload 'Type.GetInterface(string name, bool ingoreCase)' or call this method instead.
        /// </summary>
        public static Type GetInterface_PlatformSafe(this Type type, string name)
        {
            return PlatformHelper.Type_GetInterface_PlatformSafe(type, name);
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
            PlatformHelper.XDocument_Save_PlatformSafe(doc, fileName);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XElement.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void Save_PlatformSafe(this XElement element, string fileName)
        {
            PlatformHelper.XElement_Save_PlatformSafe(element, fileName);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XElement.Save(Stream) exists on Windows Phone 8, but not in .NET 3.5.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void Save_PlatformSafe(this XElement element, Stream stream)
        {
            PlatformHelper.XElement_Save_PlatformSafe(element, stream);
        }

        /// <summary>
        /// .Net 4.5 substitute
        /// </summary>
        public static TAttribute GetCustomAttribute_PlatformSupport<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return PlatformHelper.PropertyInfo_GetCustomAttribute_PlatformSupport<TAttribute>(propertyInfo);
        }

        /// <summary>
        /// .Net 4.5 substitute
        /// </summary>
        public static void SetValue_PlatformSupport(this PropertyInfo propertyInfo, object obj, object value)
        {
            PlatformHelper.PropertyInfo_SetValue_PlatformSupport(propertyInfo, obj, value);
        }

        /// <summary>
        /// .NET 4.5 substitute and for iOS compatibility: PropertyInfo.GetValue in Mono on a generic type may cause JIT compilation, which is not supported by iOS.
        /// Use 'PropertyInfo.GetGetMethod().Invoke(object obj, params object[] parameters)' or call this method instead.
        /// </summary>
        public static object GetValue_PlatformSafe(this PropertyInfo propertyInfo, object obj, params object[] parameters)
        {
            // TODO: Is the original GetValue not without params. Why make a substitute different than what it substitutes?
            return PlatformHelper.PropertyInfo_GetValue_PlatformSafe(propertyInfo, obj, parameters);
        }

    }
}
