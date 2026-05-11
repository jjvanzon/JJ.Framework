namespace JJ.Framework.Compilation.Core.Tests;

internal class DotNetInfoAccessor
{
    private const string TYPE_NAME_SHORT = "DotNetInfo";

    private readonly AccessorCore _accessor;

    public DotNetInfoAccessor()
        => _accessor = new(TYPE_NAME_SHORT);

    public DotNetInfoAccessor(DotNetCommandEnum commandEnum)
        => _accessor = new(TYPE_NAME_SHORT, commandEnum);

    public DotNetInfoAccessor(string command)
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
        get => _accessor.Get<string>() ?? "";
        set => _accessor.Set(value);
    }

    public string ID
    {
        get => _accessor.Get<string>() ?? "";
        set => _accessor.Set(value);
    }

    public string Ver
    {
        get => _accessor.Get<string>() ?? "";
        set => _accessor.Set(value);
    }

    public string Args
    {
        get => _accessor.Get<string>() ?? "";
        set => _accessor.Set(value);
    }

    public bool IsRebuild
    {
        get => _accessor.Get<bool>();
        set => _accessor.Set(value);
    }
}
