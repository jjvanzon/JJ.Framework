namespace JJ.Framework.Compilation.Core.Tests.Accessors;

internal static class DotNetLoggerAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetLogger");

    public static void Log(DotNetInfoAccessor info, DotNetOptions opt, string fullArgs) 
        => _accessor.Call(info.Obj, opt, fullArgs, nameof(Log)); 
}
