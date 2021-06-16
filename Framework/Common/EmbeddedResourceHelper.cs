using System;
using System.IO;
using System.Reflection;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Embedded resources may be content stored
    /// directly in an Assembly's exe or dll.
    /// This class helps with getting embedded resources,
    /// which otherwise may need a surprising syntax.
    /// This class aims to make it a bit easier by parameterizing it,
    /// verifying that the embedded resource exists
    /// and allows doing it in a single code line.
    /// </summary>
    public static class EmbeddedResourceHelper
    {
        public static string GetEmbeddedResourceText(Assembly assembly, string fileName) 
            => GetEmbeddedResourceText(assembly, null, fileName);

        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string fileName) 
            => GetEmbeddedResourceBytes(assembly, null, fileName);

        public static Stream GetEmbeddedResourceStream(Assembly assembly, string fileName)
            => GetEmbeddedResourceStream(assembly, null, fileName);

        public static string GetEmbeddedResourceName(Assembly assembly, string fileName)
            => GetEmbeddedResourceName(assembly, null, fileName);

        /// <param name="subNameSpace">Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetEmbeddedResourceText(Assembly assembly, string subNameSpace, string fileName)
        {
            using (Stream stream = GetEmbeddedResourceStream(assembly, subNameSpace, fileName))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }

        /// <param name="subNameSpace">Similar to the subfolder in which the embedded resource resides.</param>
        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string subNameSpace, string fileName)
        {
            using (Stream stream = GetEmbeddedResourceStream(assembly, subNameSpace, fileName))
            {
                using (var stream2 = new MemoryStream())
                {
                    stream.CopyTo(stream2);
                    return stream2.ToArray();
                }
            }
        }

        /// <param name="subNameSpace">Similar to the subfolder in which the embedded resource resides.</param>
        public static Stream GetEmbeddedResourceStream(Assembly assembly, string subNameSpace, string fileName)
        {
            string resourceName = GetEmbeddedResourceName(assembly, subNameSpace, fileName);
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new Exception($"Embedded resource '{resourceName}' not found.");
            }

            return stream;
        }

        /// <param name="subNameSpace">Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetEmbeddedResourceName(Assembly assembly, string subNameSpace, string fileName)
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