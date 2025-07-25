﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PossibleNullReferenceException

namespace JJ.Framework.PlatformCompatibility.Legacy
{
    /// <summary>
    /// This class provides various alternatives to parts of .NET that do not work on certain platforms.
    /// It exists as a helper to get immediate overview over various platform compatibility issues.
    /// Some of these methods are also accessible as extension methods that become visible
    /// in intellisense if you try to access a platform-unsafe member.
    /// </summary>
    public static partial class PlatformHelper
    {
        // MemberInfo

        /// <summary>
        /// Windows Phone / Unity compatibility:
        /// Don't switch on MemberInfo.MemberType. It produced a strange exception when deployed to Windows Phone 8 using Unity
        /// 4.3.4:
        /// "Method not found: 'System.Reflection.MemberTypes".
        /// Use 'is PropertyInfo' and such or call this method instead.
        /// </summary>
        /// <inheritdoc cref="_membertype" />
        public static MemberTypes_PlatformSafe MemberInfo_MemberType_PlatformSafe(MemberInfo memberInfo)
        {
            if (memberInfo == null) throw new ArgumentNullException(nameof(memberInfo));

            switch (memberInfo)
            {
                case PropertyInfo _: return MemberTypes_PlatformSafe.Property;
                case FieldInfo _: return MemberTypes_PlatformSafe.Field;
                case MethodInfo _: return MemberTypes_PlatformSafe.Method;
                case ConstructorInfo _: return MemberTypes_PlatformSafe.Constructor;
                case EventInfo _: return MemberTypes_PlatformSafe.Event;

                case Type type:
                {
                    if (type.IsNested)
                    {
                        return MemberTypes_PlatformSafe.NestedType;
                    }
                    else
                    {
                        return MemberTypes_PlatformSafe.TypeInfo;
                    }
                }
            }

            throw new NotSupportedException($"{nameof(memberInfo)} has the unsupported type: '{memberInfo.GetType()}'");
        }

        // Encoding

        /// <summary> The overload with only byte[] does not work on Windows Phone 8. </summary>
        public static string GetString_PlatformSafe(Encoding encoding, byte[] bytes) => encoding.GetString(bytes, 0, bytes.Length);

        // CultureInfo

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// CultureInfo.GetCultureInfo(string name) is not supported on Windows Phone 8.
        /// Use 'new CultureInfo(string name)' or call this method instead.
        /// </summary>
        public static CultureInfo GetCultureInfo_PlatformSafe(string name) => new CultureInfo(name);

        // Type

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// Type.GetInterface(string name) is not supported on Windows Phone 8.
        /// Use the overload 'Type.GetInterface(string name, bool ignoreCase)' or call this method instead.
        /// </summary>
        public static Type Type_GetInterface_PlatformSafe([Dyn(Interfaces)] Type type, string name) => type.GetInterface(name, ignoreCase: false);

        // XDocument / XElement

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XDocument.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// Beware that this overload simply saves the root node
        /// and does not the features unique to XDocument.
        /// </summary>
        public static void XDocument_Save_PlatformSafe(XDocument doc, string fileName) => XElement_Save_PlatformSafe(doc.Root, fileName);

        /// <summary>
        /// Windows Phone 8 compatibility:
        /// XElement.Save(string fileName) does not exist on Windows Phone 8.
        /// Use 'XElement.Save(TextWriter)' or call this method instead.
        /// </summary>
        public static void XElement_Save_PlatformSafe(XElement element, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XElement_Save_PlatformSafe(element, stream);
            }
        }

        /// <summary>
        /// Windows Phone 8 compatibility:
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

        // PropertyInfo

        /// <summary>
        /// iOS compatibility: PropertyInfo.GetValue in Mono on a generic type may cause JIT compilation, which is not supported by
        /// iOS.
        /// Use 'PropertyInfo.GetGetMethod().Invoke(object obj, params object[] parameters)' or call this method instead.
        /// </summary>
        public static object PropertyInfo_GetValue_PlatformSafe(PropertyInfo propertyInfo, object obj, params object[] parameters)
        {
            if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));

            return propertyInfo.GetGetMethod().Invoke(obj, parameters);
        }
    }
}
