using System;
using System.Reflection;

namespace JJ.Framework.IO.Tests
{
    internal static class TestHelper
    {
        public static string GenerateFolderName(MethodBase methodBase) => $"{methodBase.Name}_{Guid.NewGuid()}";
        public static string GenerateFileName(MethodBase methodBase) => $"{methodBase.Name}_{Guid.NewGuid()}.txt";
    }
}
