namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = Bases)]
internal class DotNetOptionsAccessor(DotNetOptions opt)
{
    private readonly AccessorCore _accessor = new(opt, typeof(DotNetOptions));

    public string DebuggerDisplay => _accessor.Get<string>()!;
}
