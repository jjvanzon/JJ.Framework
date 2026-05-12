namespace JJ.Framework.Compilation.Core.Tests.Accessors;

internal class DotNetInfoAccessor
{
    private const string TYPE_NAME_SHORT = "DotNetInfo";

    private readonly AccessorCore _accessor;

    [Suppress("Trimmer", "IL2026", Justification = GetTypes)]
    public DotNetInfoAccessor()
        => _accessor = new(TYPE_NAME_SHORT);

    [Suppress("Trimmer", "IL2026", Justification = GetTypes)]
    public DotNetInfoAccessor(DotNetCommandEnum commandEnum)
        => _accessor = new(TYPE_NAME_SHORT, commandEnum);

    [Suppress("Trimmer", "IL2026", Justification = GetTypes)]
    public DotNetInfoAccessor(string command)
        => _accessor = new(TYPE_NAME_SHORT, command);

    public object Obj
        => _accessor.Obj ?? throw new ArgumentNullException(nameof(Obj));

    [Suppress("Trimmer", "IL2026", Justification = Bases)]
    public DotNetCommandEnum CommandEnum
    {
        get => _accessor.Get<DotNetCommandEnum>();
        set => _accessor.Set(value);
    }

    [Suppress("Trimmer", "IL2026", Justification = Bases)]
    public string Command
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    [Suppress("Trimmer", "IL2026", Justification = Bases)]
    public string ID
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    [Suppress("Trimmer", "IL2026", Justification = Bases)]
    public string Ver
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    [Suppress("Trimmer", "IL2026", Justification = Bases)]
    public string Args
    {
        get => _accessor.Get<string>()!;
        set => _accessor.Set(value);
    }

    [Suppress("Trimmer", "IL2026", Justification = Bases)]
    public bool IsRebuild
    {
        get => _accessor.Get<bool>();
        set => _accessor.Set(value);
    }
}
