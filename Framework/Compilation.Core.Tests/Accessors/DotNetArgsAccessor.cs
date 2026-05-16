namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = GetTypesAnd + Bases)]
internal class DotNetArgsAccessor : AccessorCore
{
    public DotNetArgsAccessor(DotNetCommandEnum commandEnum)
        : base(typeof(DotNetArgs), commandEnum) { }

    public new DotNetArgs Obj => (DotNetArgs)base.Obj!;

    public string Args
    {
        get => Get<string>()!;
        set => Set(value);
    }

    public string FullArgs 
    {
        get => Get<string>()!;
        set => Set(value);
    }
}
