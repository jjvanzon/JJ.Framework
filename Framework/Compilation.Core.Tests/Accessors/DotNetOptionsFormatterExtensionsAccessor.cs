namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetOptionsFormatterExtensionsAccessor
{
    private static readonly AccessorCore _accessor = new ("DotNetOptionsExtensions");

    public static string Stringify(this DotNetOptions opt)
        => (string)_accessor.Call(opt)!;

    public static string DebuggerDisplay(this DotNetOptions opt) 
        => (string)_accessor.Call(opt)!;

    public static string Descriptor(this DotNetOptions opt, int? maxPathChars = null)
        => (string)_accessor.Call(opt, maxPathChars)!;
}
