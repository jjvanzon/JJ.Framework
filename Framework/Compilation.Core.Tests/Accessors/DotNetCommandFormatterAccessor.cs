namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetCommandFormatterAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetCommandFormatter");

    public static string FormatArgs(DotNetArgs args, DotNetOptions opt) =>
        (string)_accessor.Call(args, opt)!;
}
