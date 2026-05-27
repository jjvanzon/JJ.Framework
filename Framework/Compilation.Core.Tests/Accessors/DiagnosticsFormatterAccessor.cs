namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DiagnosticsFormatterAccessor
{
    private static readonly Type? _ = null;

    private static readonly AccessorCore _accessor = new("DiagnosticsFormatter");

    // Opt

    public static string? Descriptor(DotNetOptions opt, int? maxPathChars = null)
        => (string?)_accessor.Call(opt, maxPathChars);

    public static string? Stringify(DotNetOptions opt)
        => (string?)_accessor.Call([ opt ], [ typeof(DotNetOptions) ]);

    public static string? DebuggerDisplay(DotNetOptions opt)
        => (string?)_accessor.Call([ opt ], [ typeof(DotNetOptions) ]);

    // Args

    public static string? Descriptor(DotNetArgs? args) 
        => (string?)_accessor.Call([ args ], [ typeof(DotNetArgs) ]);

    public static string? Stringify(DotNetArgs? args)
        => (string?)_accessor.Call([ args ], [ typeof(DotNetArgs) ]);

    public static string? DebuggerDisplay(DotNetArgs? args)
        => (string?)_accessor.Call([ args ], [ typeof(DotNetArgs) ]);

    // Result

    public static string? Descriptor(DotNetResult? result, bool singleLine = false)
        => (string?)_accessor.Call(Name(), result, singleLine);

    public static string? Stringify(DotNetResult? result)
        => (string?)_accessor.Call([ result ], [ typeof(DotNetResult) ]);

    public static string? DebuggerDisplay(DotNetResult? result)
        => (string?)_accessor.Call([ result ], [ typeof(DotNetResult) ]);

    public static string? ExceptionMessage(DotNetResult? result)
        => (string?)_accessor.Call([ result ], [ typeof(DotNetResult) ]);

    // Parts

    public static string? CommandDescriptor(DotNetCommandEnum @enum, string? command, bool isRebuild) 
        => (string?)_accessor.Call(@enum, command, isRebuild);

    public static string? IDVerDescriptor(string? id, string? ver)
        => (string?)_accessor.Call(Name(), id, ver);

    public static string? ArgsDescriptor(string? args, string? fullArgs)
        => (string?)_accessor.Call(Name(), args, fullArgs);
}
