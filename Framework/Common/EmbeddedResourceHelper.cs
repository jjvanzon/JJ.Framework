using System;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;

namespace JJ.Framework.Common
{
	[PublicAPI]
	public static class EmbeddedResourceHelper
	{
		public static string GetEmbeddedResourceText(Assembly assembly, string fileName) 
			=> GetEmbeddedResourceText(assembly, null, fileName);

		public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string fileName) 
			=> GetEmbeddedResourceBytes(assembly, null, fileName);

		public static Stream GetEmbeddedResourceStream(Assembly assembly, string fileName) 
			=> GetEmbeddedResourceStream(assembly, null, fileName);

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