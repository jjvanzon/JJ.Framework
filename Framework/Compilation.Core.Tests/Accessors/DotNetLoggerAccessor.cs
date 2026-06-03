namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetLoggerAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetLogger");

    public static void LogAction(DotNetArgs args, DotNetOptions opt) 
        => _accessor.Call(args, opt); 
}
