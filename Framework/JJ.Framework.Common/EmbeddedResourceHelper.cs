// ReSharper disable UnusedVariable
using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Common.Legacy 
{
    /// <inheritdoc cref="_embeddedresourcehelper" />
    public static class EmbeddedResourceHelper
    {
        /// <inheritdoc cref="_embeddedresourcehelper" />
        public static string GetEmbeddedResourceText(Assembly assembly, string fileName)
        {
            return GetEmbeddedResourceText(assembly, null, fileName);
        }

        /// <inheritdoc cref="_embeddedresourcehelper" />
        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string fileName)
        {
            return GetEmbeddedResourceBytes(assembly, null, fileName);
        }

        /// <inheritdoc cref="_embeddedresourcehelper" />
        public static Stream GetEmbeddedResourceStream(Assembly assembly, string fileName)
        {
            return GetEmbeddedResourceStream(assembly, null, fileName);
        }
       
        // Copied from 2021 version
        /// <inheritdoc cref="_embeddedresourcehelper" />
        public static string GetEmbeddedResourceName(Assembly assembly, string fileName)
            => GetEmbeddedResourceName(assembly, null, fileName);

        /// <inheritdoc cref="_embeddedresourcehelper" />
        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetEmbeddedResourceText(Assembly assembly, string subNamespace, string fileName)
        {
            using (Stream stream = GetEmbeddedResourceStream(assembly, subNamespace, fileName))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }

        /// <inheritdoc cref="_embeddedresourcehelper" />
        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string subNamespace, string fileName)
        {
            string resourceName = GetEmbeddedResourceName(assembly, subNamespace, fileName);
            using (Stream stream = GetEmbeddedResourceStream(assembly, subNamespace, fileName))
            {
                using (var stream2 = new MemoryStream())
                {
                    Stream_PlatformSupport.CopyTo(stream, stream2);
                    return stream2.ToArray();
                }
            }
        }

        /// <inheritdoc cref="_embeddedresourcehelper" />
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

        /// <inheritdoc cref="_embeddedresourcehelper" />
        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetEmbeddedResourceName(Assembly assembly, string subNamespace, string fileName)
        {
            // Pre-conditions copied from 2021 version
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException($"{nameof(fileName)} is null or white space.");
            
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
