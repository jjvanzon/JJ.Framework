namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetArgsFormatterExtensionsAccessor
{
    private static readonly AccessorCore _accessor = new ("DotNetArgsFormatterExtensions");

    public static string Stringify      (this DotNetArgs? args) => (string)_accessor.Call(args)!;
    public static string DebuggerDisplay(this DotNetArgs? args) => (string)_accessor.Call(args)!;
    public static string Descriptor     (this DotNetArgs? args) => (string)_accessor.Call(args)!;
}
