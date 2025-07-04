using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Static variant of preserved copy of PlatformExtensions class, that would otherwise have been deleted in a cherry-picked commit, while still being used.

namespace JJ.Framework.PlatformCompatibility.Legacy
{
    /// <inheritdoc cref="_platformhelper"/>
    public static class PlatformHelperLegacy
    {
        /// <inheritdoc cref="_join" />
        public static string String_Join_PlatformSupport<T>(string separator, IEnumerable<T> values)
        {
            return String.Join(separator, values.Select(x => x.ToString()).ToArray());
        }

        /// <inheritdoc cref="_copyto" />
        public static void Stream_CopyTo_PlatformSupport(Stream source, Stream dest, int bufferSize)
        {
            int bytesRead;
            byte[] buffer = new byte[bufferSize];
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                dest.Write(buffer, 0, bytesRead);
            }
        }

        /// <inheritdoc cref="_isnullorwhitespace" />
        public static bool String_IsNullOrWhiteSpace_PlatformSupport(string value)
        {
            if (value == null)
            {
                return true;
            }

            if (String.Equals(value, ""))
            {
                return true;
            }

            if (String.Equals(value.Trim(), ""))
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc cref="_getcustomattribute" />
        public static TAttribute PropertyInfo_GetCustomAttribute_PlatformSupport<TAttribute>(PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(TAttribute));
        }

        /// <inheritdoc cref="_setvalue" />
        public static void PropertyInfo_SetValue_PlatformSupport(PropertyInfo propertyInfo, object obj, object value)
        {
            propertyInfo.SetValue(obj, value, null);
        }
    }
}
