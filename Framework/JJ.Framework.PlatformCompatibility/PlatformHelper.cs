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
    /// It exists as a helper to get immediate overview over various platform compatibility issues.
    /// It also exists as extension methods that become visible in intellisense if you try to access
    /// a platform-unsafe member.
    /// </summary>
    public static class PlatformHelper
    {
        /// <summary>
        /// Windows Phone / Unity compatibility:
        /// Don't switch on MemberInfo.MemberType. It produced a strange exception when deployed to Windows Phone using Unity:
        /// "Method not found: 'System.Reflection.MemberTypes".
        /// Use 'is PropertyInfo' and such or call this method instead.
        /// </summary>
        public static MemberTypes_PlatformSafe MemberInfo_MemberType_PlatformSafe(MemberInfo memberInfo)
        {
            if (memberInfo == null) throw new ArgumentNullException("memberInfo");

            if (memberInfo is PropertyInfo)
            {
                return MemberTypes_PlatformSafe.Property;
            }

            if (memberInfo is FieldInfo)
            {
                return MemberTypes_PlatformSafe.Field;
            }

            if (memberInfo is MethodBase)
            {
                return MemberTypes_PlatformSafe.Method;
            }

            if (memberInfo is EventInfo)
            {
                return MemberTypes_PlatformSafe.Event;
            }

            if (memberInfo is Type)
            {
                return MemberTypes_PlatformSafe.TypeInfo;
            }

            throw new Exception(String.Format("memberInfo has the unsupported type: '{0}'", memberInfo.GetType()));
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// CultureInfo.GetCultureInfo(string name) is not supported on Windows Phone 8.
        /// Use 'new CultureInfo(string name)' or call this method instead.
        /// </summary>
        public static CultureInfo CultureInfo_GetCultureInfo_PlatformSafe(string name)
        {
            return new CultureInfo(name);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// Type.GetInterface(string name) is not supported on Windows Phone 8.
        /// Use the overload 'Type.GetInterface(string name, bool ingoreCase)' or call this method instead.
        /// </summary>
        public static Type Type_GetInterface_PlatformSafe(Type type, string name)
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
        public static void XDocument_Save_PlatformSafe(XDocument doc, string fileName)
        {
            XElement_Save_PlatformSafe(doc.Root, fileName);
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XElement.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void XElement_Save_PlatformSafe(XElement element, string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XElement_Save_PlatformSafe(element, stream);
            }
        }

        /// <summary>
        /// XElement.Save(Stream) exists on Windows Phone 8, but not in .NET 3.5.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void XElement_Save_PlatformSafe(XElement element, Stream stream)
        {
            using (TextWriter writer = new StreamWriter(stream))
            {
                element.Save(writer);
            }
        }

        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static string String_Join_PlatformSupport<T>(string separator, IEnumerable<T> values)
        {
            return String.Join(separator, values.Select(x => x.ToString()).ToArray());
        }

        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static void Stream_CopyTo_PlatformSupport(Stream source, Stream dest, int bufferSize)
        {
            int bytesRead;
            byte[] buffer = new byte[bufferSize];
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                dest.Write(buffer, 0, bytesRead);
            }
        }

        /// <summary>
        /// .Net 4 substitute
        /// </summary>
        public static bool String_IsNullOrWhiteSpace_PlatformSupport(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }

            if (String.Equals(value.Trim(), ""))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// .Net 4.5 substitute
        /// </summary>
        public static TAttribute PropertyInfo_GetCustomAttribute_PlatformSupport<TAttribute>(MemberInfo propertyInfo)
            where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(TAttribute));
        }

        /// <summary>
        /// .Net 4.5 substitute
        /// </summary>
        public static void PropertyInfo_SetValue_PlatformSupport(PropertyInfo propertyInfo, object obj, object value)
        {
            propertyInfo.SetValue(obj, value, null);
        }

        /// <summary>
        /// .Net 4.5 substitute and for iOS compatibility: PropertyInfo.GetValue in Mono on a generic type may cause JIT compilation, which is not supported by iOS.
        /// Use 'PropertyInfo.GetGetMethod().Invoke(object obj, params object[] parameters)' or call this method instead.
        /// </summary>
        public static object PropertyInfo_GetValue_PlatformSafe(PropertyInfo propertyInfo, object obj, object[] index)
        {
            if (propertyInfo == null) throw new ArgumentNullException("propertyInfo");

            return propertyInfo.GetGetMethod().Invoke(obj, index);
        }
    }
}
