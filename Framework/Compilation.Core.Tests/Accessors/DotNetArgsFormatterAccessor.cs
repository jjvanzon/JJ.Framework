namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetArgsFormatterAccessor
{
    private static readonly Type? _ = null;

    private static readonly AccessorCore _accessor = new("DotNetArgsFormatter");

    public static string? Descriptor(DotNetArgs? args) 
        => (string?)_accessor.Call(args);

    public static string? Stringify(DotNetArgs? args)
        => (string?)_accessor.Call(args);

    public static string? DebuggerDisplay(DotNetArgs? args)
        => (string?)_accessor.Call(args);

    // Parts

    public static string? CommandDescriptor(DotNetCommandEnum @enum, string? command, bool isRebuild) 
        => (string?)_accessor.Call(@enum, command, isRebuild);

    public static string? IDVerDescriptor(string? id, string? ver)
        => (string?)_accessor.Call(Name(), id, ver);

    public static string? ArgPropsDescriptor(string? args, string? fullArgs)
        => (string?)_accessor.Call(Name(), args, fullArgs);
}
