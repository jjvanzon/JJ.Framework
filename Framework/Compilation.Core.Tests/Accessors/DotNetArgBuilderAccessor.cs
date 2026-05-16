namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetArgBuilderAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetArgBuilder");

    public static string FormatArgs(DotNetArgsAccessor args, DotNetOptions opt) =>
        (string)_accessor.Call(args.Obj, opt)!;
}
