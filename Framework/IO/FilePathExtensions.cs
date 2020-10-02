using System.IO;
using JetBrains.Annotations;

namespace JJ.Framework.IO
{
	[PublicAPI]
	public static class FilePathExtensions
	{
		public static byte[] ReadAllBytes(this string filePath) => File.ReadAllBytes(filePath);
	}
}
