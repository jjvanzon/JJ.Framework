namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetOptionsFormatterAccessor
{
    private static readonly Type? _ = null;

    private static readonly AccessorCore _accessor = new("DotNetOptionsFormatter");

    // Opt

    public static string? Descriptor(DotNetOptions opt, int? maxPathChars = null)
        => (string?)_accessor.Call(opt, maxPathChars);

    public static string? Stringify(DotNetOptions opt)
        => (string?)_accessor.Call([ opt ], [ typeof(DotNetOptions) ]);

    public static string? DebuggerDisplay(DotNetOptions opt)
        => (string?)_accessor.Call([ opt ], [ typeof(DotNetOptions) ]);
}
