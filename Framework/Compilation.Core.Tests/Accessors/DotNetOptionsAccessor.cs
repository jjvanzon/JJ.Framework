namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = Bases)]
internal static class DotNetOptionsAccessor
{
    private static readonly AccessorCore _static = new(typeof(DotNetOptions));

    public static int DEFAULT_TIME_OUT_SEC => _static.Get<int>();
}
