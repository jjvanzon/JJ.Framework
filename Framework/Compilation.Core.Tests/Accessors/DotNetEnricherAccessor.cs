namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetEnricherAccessor
{
    private static readonly AccessorCore _accessor = new("DotNetEnricher");

    public static void Enrich(DotNetArgs args) => _accessor.Call(args);
}
