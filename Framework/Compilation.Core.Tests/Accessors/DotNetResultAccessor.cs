namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = Bases)]
internal class DotNetResultAccessor(DotNetResult obj)
{
    private readonly AccessorCore _accessor = new(typeof(DotNetResult), obj);

    public string DebuggerDisplay => _accessor.Get<string>()!;
}

