namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetArgBuilderAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetArgBuilder");

    public static string FormatArgs(DotNetInfoAccessor info, DotNetOptions opt) =>
        (string)_accessor.Call(info.Obj, opt)!;
}
