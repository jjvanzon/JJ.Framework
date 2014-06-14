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
        private static Stream GetEmbeddedResourceStream(Assembly assembly, string subNamespace, string fileName)
        {
            string resourceName = GetEmbeddedResourceName(assembly, subNamespace, fileName);
            return assembly.GetManifestResourceStream(resourceName);
        }

        /// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
        public static string GetEmbeddedResourceName(Assembly assembly, string subNamespace, string fileName)
        {
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
