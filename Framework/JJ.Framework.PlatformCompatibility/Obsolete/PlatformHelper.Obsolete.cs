﻿using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.PlatformCompatibility.Legacy.Obsolete
{
    /// <inheritdoc cref="_platformhelper" />
    public static partial class PlatformHelper
    {
        /// <inheritdoc cref="_membertype" />
        [Obsolete("Use MemberType_PlatformSafe instead.", true)]
        public static MemberTypes_PlatformSafe MemberInfo_MemberType_PlatformSafe(MemberInfo memberInfo)
            => throw new NotSupportedException("Use MemberType_PlatformSafe instead.");

        /// <inheritdoc cref="_getcultureinfo" />
        [Obsolete("Use GetCultureInfo_PlatformSafe instead.", true)]
        public static CultureInfo CultureInfo_GetCultureInfo_PlatformSafe(string name)
            => throw new NotSupportedException("Use GetCultureInfo_PlatformSafe instead.");

        /// <inheritdoc cref="_getinterface" />
        [Obsolete("Use GetInterface_PlatformSafe instead.", true)]
        public static Type Type_GetInterface_PlatformSafe(Type type, string name)
            => throw new NotSupportedException("Use GetInterface_PlatformSafe instead.");

        /// <inheritdoc cref="_xdocumentsave" />
        [Obsolete("Use Save_PlatformSafe instead.", true)]
        public static void XDocument_Save_PlatformSafe(XDocument doc, string fileName)
            => throw new NotSupportedException("Use Save_PlatformSafe instead.");

        /// <inheritdoc cref="_xelementsave" />
        [Obsolete("Use Save_PlatformSafe instead.", true)]
        public static void XElement_Save_PlatformSafe(XElement element, string fileName)
            => throw new NotSupportedException("Use Save_PlatformSafe instead.");

        /// <inheritdoc cref="_xelementsave" />
        [Obsolete("Use Save_PlatformSafe instead.", true)]
        public static void XElement_Save_PlatformSafe(XElement element, Stream stream)
            => throw new NotSupportedException("Use Save_PlatformSafe instead.");

        /// <inheritdoc cref="_getvalue" />
        [Obsolete("Use GetValue_PlatformSafe instead.", true)]
        public static object PropertyInfo_GetValue_PlatformSafe(PropertyInfo propertyInfo, object obj, params object[] parameters)
            => throw new NotSupportedException("Use GetValue_PlatformSafe instead.");
    }
}
