using System;
using System.IO;
using System.Reflection;

namespace JJ.Framework.IO.Tests
{
	internal static class TestHelper
	{
		public static string GenerateFolderName(MethodBase methodBase) => $"{methodBase.Name}_{Path.GetRandomFileName().Replace(".", "")}";
		public static string GenerateFileName(MethodBase methodBase) => $"{methodBase.Name}_{Path.GetRandomFileName().Replace(".", "")}.txt";
	}
}
