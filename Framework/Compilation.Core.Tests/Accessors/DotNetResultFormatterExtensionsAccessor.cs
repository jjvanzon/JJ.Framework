namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetResultFormatterExtensionsAccessor
{
    private static readonly AccessorCore _accessor = new ("DotNetResultFormatterExtensions");

    public static string Stringify(this DotNetResult? result) 
        => (string)_accessor.Call(Name(), result)!;

    public static string DebuggerDisplay(this DotNetResult? result) 
        => (string)_accessor.Call(Name(), result)!;

    public static string ExceptionMessage(this DotNetResult? result)
        => (string)_accessor.Call(Name(), result)!;

    public static string Descriptor(this DotNetResult? result, bool singleLine = false)
        => (string)_accessor.Call(Name(), result, singleLine)!;
}
