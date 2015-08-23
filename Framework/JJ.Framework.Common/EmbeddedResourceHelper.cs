using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Common
{
    public static class EmbeddedResourceHelper
    {
        public static string GetEmbeddedResourceText(Assembly assembly, string fileName)
        {
            return GetEmbeddedResourceText(assembly, null, fileName);
        }

        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string fileName)
        {
            return GetEmbeddedResourceBytes(assembly, null, fileName);
        }

        public static Stream GetEmbeddedResourceStream(Assembly assembly, string fileName)
        {
            return GetEmbeddedResourceStream(assembly, null, fileName);
        }

        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetEmbeddedResourceText(Assembly assembly, string subNamespace, string fileName)
        {
            using (Stream stream = GetEmbeddedResourceStream(assembly, subNamespace, fileName))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }

        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string subNamespace, string fileName)
        {
            using (Stream stream = GetEmbeddedResourceStream(assembly, subNamespace, fileName))
            {
                using (var stream2 = new MemoryStream())
                {
                    Stream_PlatformSupport.CopyTo(stream, stream2);
                    return stream2.ToArray();
                }
            }
        }

        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static Stream GetEmbeddedResourceStream(Assembly assembly, string subNamespace, string fileName)
        {
            string resourceName = GetEmbeddedResourceName(assembly, subNamespace, fileName);
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new Exception(String.Format("Embedded resource '{0}' not found.", GetEmbeddedResourceName(assembly, subNamespace, fileName)));
            }
            return stream;
        }

        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetEmbeddedResourceName(Assembly assembly, string subNamespace, string fileName)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            if (String.IsNullOrEmpty(subNamespace))
            {
                string embeddedResourceName = String.Format("{0}.{1}", assembly.GetName().Name, fileName);
                return embeddedResourceName;
            }
            else
            {
                string embeddedResourceName = String.Format("{0}.{1}.{2}", assembly.GetName().Name, subNamespace, fileName);
                return embeddedResourceName;
            }
        }
    }
}
