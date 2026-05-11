namespace JJ.Framework.Compilation.Core.Tests;

internal static class DotNetEnricherAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetEnricher");

    public static void Enrich(DotNetInfoAccessor info) => _accessor.Call(info.Obj);
}
