namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetCmdFormatterAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetCmdFormatter");

    public static string FormatArgs(DotNetArgs args, DotNetOptions opt) =>
        (string)_accessor.Call(args, opt)!;
}
