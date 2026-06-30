using System.Runtime.CompilerServices;

namespace JJ.Framework.IO.Core.Tests
{
    internal static class TestHelper
    {
        public static string GenerateFolderName([CallerMemberName] string name = "") => $"{name}_{Path.GetRandomFileName().Replace(".", "")}";
        public static string GenerateFileName([CallerMemberName] string name = "") => $"{name}_{Path.GetRandomFileName().Replace(".", "")}.txt";
    }
}
