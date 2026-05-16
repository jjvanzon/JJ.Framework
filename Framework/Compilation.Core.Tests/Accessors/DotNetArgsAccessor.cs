namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = GetTypesAnd + Bases)]
internal class DotNetArgsAccessor : AccessorCore
{
    //private const string TYPE_NAME_SHORT = "DotNetArgs";

    //public DotNetArgsAccessor() 
    //    : base(typeof(DotNetArgs)) { }

    public DotNetArgsAccessor(DotNetCommandEnum commandEnum)
        : base(typeof(DotNetArgs), commandEnum) { }

    //public DotNetArgsAccessor(string command)
    //    : base(typeof(DotNetArgs), command) { }

    //public DotNetCommandEnum CommandEnum
    //{
    //    get => Get<DotNetCommandEnum>();
    //    set => Set(value);
    //}

    //public string Command
    //{
    //    get => Get<string>()!;
    //    set => Set(value);
    //}

    //public string ID
    //{
    //    get => Get<string>()!;
    //    set => Set(value);
    //}

    //public string Ver
    //{
    //    get => Get<string>()!;
    //    set => Set(value);
    //}

    public string Args
    {
        get => Get<string>()!;
        set => Set(value);
    }

    //public bool IsRebuild
    //{
    //    get => Get<bool>();
    //    set => Set(value);
    //}

    public string FullArgs 
    {
        get => Get<string>()!;
        set => Set(value);
    }
}
