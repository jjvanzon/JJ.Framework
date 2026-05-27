namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetResultFormatterAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetResultFormatter");

    public static string? Descriptor(DotNetResult? result, bool singleLine = false)
        => (string?)_accessor.Call(Name(), result, singleLine);

    public static string? Stringify(DotNetResult? result)
        => (string?)_accessor.Call(Name(), result);

    public static string? DebuggerDisplay(DotNetResult? result)
        => (string?)_accessor.Call(Name(), result);

    public static string? ExceptionMessage(DotNetResult? result)
        => (string?)_accessor.Call(Name(), result);
}
