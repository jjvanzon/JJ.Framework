namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DiagnosticsFormatterAccessor
{
    private static readonly Type? _ = null;

    private static readonly AccessorCore _accessor = new("DiagnosticsFormatter");

    public static string? Descriptor(DotNetOptions opt, char quote = '"')
        => (string?)_accessor.Call(opt, quote);

    public static string? Stringify(DotNetOptions opt)
        => (string?)_accessor.Call([ opt ], [ typeof(DotNetOptions) ]);

    public static string? DebuggerDisplay(DotNetOptions opt)
        => (string?)_accessor.Call([ opt ], [ typeof(DotNetOptions) ]);

    public static string? Descriptor(DotNetArgs? args) 
        => (string?)_accessor.Call([ args ], [ typeof(DotNetArgs) ]);

    public static string? Stringify(DotNetArgs? args)
        => (string?)_accessor.Call([ args ], [ typeof(DotNetArgs) ]);

    public static string? DebuggerDisplay(DotNetArgs? args)
        => (string?)_accessor.Call([ args ], [ typeof(DotNetArgs) ]);

    public static string? CommandDescriptor(DotNetCommandEnum @enum, string? command, bool isRebuild) 
        => (string?)_accessor.Call(@enum, command, isRebuild);

    public static string? IDVerDescriptor(string? id, string? ver)
        => (string?)_accessor.Call(Name(), id, ver);

    public static string? ArgsDescriptor(string? args, string? fullArgs)
        => (string?)_accessor.Call(Name(), args, fullArgs);
}
