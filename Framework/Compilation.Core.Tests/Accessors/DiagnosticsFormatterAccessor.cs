namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DiagnosticsFormatterAccessor
{
    private static readonly AccessorCore _accessor = new("DiagnosticsFormatter");

    public static string? Descriptor(DotNetArgs? args) 
        => (string?)_accessor.Call(args);

    public static string? CommandDescriptor(DotNetCommandEnum @enum, string? command, bool isRebuild) 
        => (string?)_accessor.Call(@enum, command, isRebuild);

    public static string? IDVerDescriptor(string? id, string? ver)
        => (string?)_accessor.Call(nameof(IDVerDescriptor), [ id, ver ], [ typeof(string), typeof(string) ]);

    public static string? ArgsDescriptor(string? args, string? fullArgs)
        => (string?)_accessor.Call(nameof(ArgsDescriptor), [ args, fullArgs ], [ typeof(string), typeof(string) ]);
}
