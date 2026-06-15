namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = Bases)]
internal class DotNetOptionsAccessor(DotNetOptions opt)
{
    private readonly AccessorCore _accessor = new(opt, typeof(DotNetOptions));

    public DotNetOptions Obj => (DotNetOptions)_accessor.Obj!;

    [return: NotNullIfNotNull(nameof(accessor))]
    public static implicit operator DotNetOptions?(DotNetOptionsAccessor? accessor) => accessor?.Obj;

    public string DebuggerDisplay => _accessor.Get<string>()!;
}
