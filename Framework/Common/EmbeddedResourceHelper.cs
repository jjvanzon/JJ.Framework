using System;
using System.IO;
using System.Reflection;

namespace JJ.Framework.Common
{
	public static class EmbeddedResourceHelper
	{
		public static string GetEmbeddedResourceText(Assembly assembly, string fileName) 
			=> GetEmbeddedResourceText(assembly, null, fileName);

		public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string fileName) 
			=> GetEmbeddedResourceBytes(assembly, null, fileName);

		public static Stream GetEmbeddedResourceStream(Assembly assembly, string fileName) 
			=> GetEmbeddedResourceStream(assembly, null, fileName);

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
					stream.CopyTo(stream2);
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
				throw new Exception($"Embedded resource '{resourceName}' not found.");
			}

			return stream;
		}

		/// <param name="subNamespace">Similar to the subfolder in which the embedded resource resides.</param>
		public static string GetEmbeddedResourceName(Assembly assembly, string subNamespace, string fileName)
		{
			if (assembly == null) throw new ArgumentNullException(nameof(assembly));
			if (string.IsNullOrEmpty(subNamespace))
			{
				string embeddedResourceName = $"{assembly.GetName().Name}.{fileName}";
				return embeddedResourceName;
			}
			else
			{
				string embeddedResourceName = $"{assembly.GetName().Name}.{subNamespace}.{fileName}";
				return embeddedResourceName;
			}
		}
	}
}