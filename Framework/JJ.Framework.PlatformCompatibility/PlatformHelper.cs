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
    /// <summary>
    /// This class provides various alternatives to parts of .NET that do not work on certain platforms.
    /// </summary>
    public static class PlatformHelper
    {
        /// <summary>
        /// Windows Phone / Unity compatibility:
        /// Don't switch on MemberInfo.MemberType. It produced a strange exception when deployed to Windows Phone using Unity:
        /// "Method not found: 'System.Reflection.MemberTypes".
        /// Use 'is PropertyInfo' and such or call this method instead.
        /// </summary>
        public static PlatformSafeMemberTypes PlatformSafe_MemberType(MemberInfo memberInfo)
        {
            if (memberInfo == null) throw new ArgumentNullException("memberInfo");

            if (memberInfo is PropertyInfo)
            {
                return PlatformSafeMemberTypes.Property;
            }

            if (memberInfo is FieldInfo)
            {
                return PlatformSafeMemberTypes.Field;
            }

            if (memberInfo is MethodBase)
            {
                return PlatformSafeMemberTypes.Method;
            }

            if (memberInfo is EventInfo)
            {
                return PlatformSafeMemberTypes.Event;
            }

            if (memberInfo is Type)
            {
                return PlatformSafeMemberTypes.TypeInfo;
            }

            throw new Exception(String.Format("memberInfo has the unsupported type: '{0}'", memberInfo.GetType()));
        }

        /// <summary>
        /// iOS compatibility: PropertyInfo.GetValue in Mono on a generic type may cause JIT compilation, which is not supported by iOS.
        /// Use 'PropertyInfo.GetGetMethod().Invoke(object obj, params object[] parameters)' or call this method instead.
        /// </summary>
        public static object PlatformSafe_PropertyInfo_GetValue(PropertyInfo propertyInfo, object obj, params object[] parameters)
        {
            if (propertyInfo == null) throw new ArgumentNullException("propertyInfo");

            return propertyInfo.GetGetMethod().Invoke(obj, parameters);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// CultureInfo.GetCultureInfo(string name) is not supported on Windows Phone 8.
        /// Use 'new CultureInfo(string name)' or call this method instead.
        /// </summary>
        public static CultureInfo PlatformSafe_CultureInfo_GetCultureInfo(string name)
        {
            return new CultureInfo(name);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// Type.GetInterface(string name) is not supported on Windows Phone 8.
        /// Use the overload 'Type.GetInterface(string name, bool ingoreCase)' or call this method instead.
        /// </summary>
        public static Type PlatformSafe_Type_GetInterface(Type type, string name)
        {
            return type.GetInterface(name, ignoreCase: false);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XDocument.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// Beware that this overload simply saves the root node
        /// and does not the features unique to XDocument.
        /// </summary>
        public static void PlatformSafe_XDocument_Save(XDocument doc, string fileName)
        {
            PlatformSafe_XElement_Save(doc.Root, fileName);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XElement.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void PlatformSafe_XElement_Save(XElement element, string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PlatformSafe_XElement_Save(element, stream);
            }
        }

        /// <summary>
        /// XElement.Save(Stream) exists on Windows Phone 8, but not in .NET 3.5.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void PlatformSafe_XElement_Save(XElement element, Stream stream)
        {
            using (TextWriter writer = new StreamWriter(stream))
            {
                element.Save(writer);
            }
        }
    }
}
