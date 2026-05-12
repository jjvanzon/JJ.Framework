// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    [NoTrim("Command", "JJ.Framework.Compilation.Core.DotNetInfo", "JJ.Framework.Compilation.Core")]
    public static void Untrim() { }
}
