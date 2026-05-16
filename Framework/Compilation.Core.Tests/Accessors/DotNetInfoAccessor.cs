namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = GetTypesAnd + Bases)]
internal class DotNetArgsAccessor
{
    private const string TYPE_NAME_SHORT = "DotNetArgs";

    private readonly AccessorCore _accessor;

    public DotNetArgsAccessor()
        => _accessor = new(TYPE_NAME_SHORT);

    public DotNetArgsAccessor(DotNetCommandEnum commandEnum)
        => _accessor = new(TYPE_NAME_SHORT, commandEnum);

    public DotNetArgsAccessor(string command)
        => _accessor = new(TYPE_NAME_SHORT, command);

    public object Obj
        => _accessor.Obj ?? throw new ArgumentNullException(nameof(Obj));

    public DotNetCommandEnum CommandEnum
    {
        get => _accessor.Get<DotNetCommandEnum>();
        set => _accessor.Set(value);
    }

    public string Command
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    public string ID
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    public string Ver
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    public string Args
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    public bool IsRebuild
    {
        get => _accessor.Get<bool>();
        set => _accessor.Set(value);
    }
}
