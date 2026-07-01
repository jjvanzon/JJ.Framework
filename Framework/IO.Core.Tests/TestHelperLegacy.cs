using System.Runtime.CompilerServices;

namespace JJ.Framework.IO.Core.Tests
{
    internal static class TestHelper
    {
        public static string GenerateFolderPath([CallerMemberName] string name = "")
        {
            return Path.Combine(Path.GetTempPath(), $"{name}_{Path.GetRandomFileName().Replace(".", "")}");
        }

        public static string GenerateFilePath([CallerMemberName] string name = "")
        {
            return Path.Combine(Path.GetTempPath(), $"{name}_{Path.GetRandomFileName().Replace(".", "")}.txt");
        }
    }
}
