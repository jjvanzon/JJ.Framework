namespace JJ.Framework.Compilation.Core.Tests;

internal static class DotNetArgBuilderAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetArgBuilder");

    public static string FormatArgs(DotNetInfoAccessor info, DotNetOptions opt) =>
        (string)_accessor.Call(info.Obj, opt)!;
}
