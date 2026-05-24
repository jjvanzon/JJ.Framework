namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = GetTypesAnd + Bases)]
internal class DotNetArgsAccessor : AccessorCore
{
    public DotNetArgsAccessor()
        : base(typeof(DotNetArgs)) { }

    public DotNetArgsAccessor(DotNetCommandEnum commandEnum)
        : base(typeof(DotNetArgs), commandEnum) { }

    public DotNetArgsAccessor(string command)
        : base(typeof(DotNetArgs), command) { }

    public new DotNetArgs Obj => (DotNetArgs)base.Obj!;

    public string            Args        { set => Set(value); }
    public string            Command     { set => Set(value); }
    public DotNetCommandEnum CommandEnum { set => Set(value); }
    public bool              IsRebuild   { set => Set(value); }
    public string            ID          { set => Set(value); }
    public string            Ver         { set => Set(value); }
    public string            FullArgs    { set => Set(value); }

    public string DebuggerDisplay => Get<string>()!;
}
