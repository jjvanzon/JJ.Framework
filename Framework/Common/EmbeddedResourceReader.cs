using System;
using System.IO;
using System.Reflection;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Embedded resources may be content stored
    /// directly in an assembly's exe or dll.
    /// This class helps with getting embedded resources,
    /// which otherwise may need a surprising syntax.
    /// This class aims to make it a bit easier by parameterizing it,
    /// verifying that the embedded resource exists
    /// and allows doing it in a single code line.
    /// </summary>
    public static class EmbeddedResourceReader
    {
        public static string GetText(Assembly assembly, string fileName) 
            => GetText(assembly, null, fileName);

        public static byte[] GetBytes(Assembly assembly, string fileName) 
            => GetBytes(assembly, null, fileName);

        public static Stream GetStream(Assembly assembly, string fileName)
            => GetStream(assembly, null, fileName);

        public static string GetName(Assembly assembly, string fileName)
            => GetName(assembly, null, fileName);

        /// <param name="subNameSpace">Nullable. Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetText(Assembly assembly, string subNameSpace, string fileName)
        {
            using (Stream stream = GetStream(assembly, subNameSpace, fileName))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }

        /// <param name="subNameSpace">Nullable. Similar to the subfolder in which the embedded resource resides.</param>
        public static byte[] GetBytes(Assembly assembly, string subNameSpace, string fileName)
        {
            using (Stream stream = GetStream(assembly, subNameSpace, fileName))
            {
                using (var stream2 = new MemoryStream())
                {
                    stream.CopyTo(stream2);
                    return stream2.ToArray();
                }
            }
        }

        /// <param name="subNameSpace">Nullable. Similar to the subfolder in which the embedded resource resides.</param>
        public static Stream GetStream(Assembly assembly, string subNameSpace, string fileName)
        {
            string resourceName = GetName(assembly, subNameSpace, fileName);
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new Exception($"Embedded resource '{resourceName}' not found.");
            }

            return stream;
        }

        /// <param name="subNameSpace">Nullable. Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetName(Assembly assembly, string subNameSpace, string fileName)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException($"{nameof(fileName)} is null or white space.");

            if (string.IsNullOrEmpty(subNameSpace))
            {
                string embeddedResourceName = $"{assembly.GetName().Name}.{fileName}";
                return embeddedResourceName;
            }
            else
            {
                string embeddedResourceName = $"{assembly.GetName().Name}.{subNameSpace}.{fileName}";
                return embeddedResourceName;
            }
        }
    }
}