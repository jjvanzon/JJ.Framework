namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = Bases)]
internal class DotNetOptionsAccessor(DotNetOptions opt)
{
    private static readonly AccessorCore _static   = new(     typeof(DotNetOptions));
    private        readonly AccessorCore _instance = new(opt, typeof(DotNetOptions));

    public static int DEFAULT_TIME_OUT_SEC => _static.Get<int>();
    public string DebuggerDisplay => _instance.Get<string>()!;
}
