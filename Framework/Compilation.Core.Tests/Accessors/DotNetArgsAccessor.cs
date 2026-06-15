// ReSharper disable UnusedMember.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = GetTypesAnd + Bases)]
internal class DotNetArgsAccessor : AccessorCore
{
    public DotNetArgsAccessor()
        : base(typeof(DotNetArgs)) { }

    public DotNetArgsAccessor(DotNetArgs obj)
        : base(obj, typeof(DotNetArgs)) { }

    public DotNetArgsAccessor(DotNetCommandEnum commandEnum)
        : base(typeof(DotNetArgs), commandEnum) { }

    public DotNetArgsAccessor(string command)
        : base(typeof(DotNetArgs), command) { }

    [return: NotNullIfNotNull(nameof(accessor))]
    public static implicit operator DotNetArgs?(DotNetArgsAccessor? accessor) => accessor?.Obj;

    public new DotNetArgs Obj => (DotNetArgs)base.Obj!;

    public string            Args        { get => (string           )Get()!; set => Set(value); }
    public string            Command     { get => (string           )Get()!; set => Set(value); }
    public DotNetCommandEnum CommandEnum { get => (DotNetCommandEnum)Get()!; set => Set(value); }
    public bool              IsRebuild   { get => (bool             )Get()!; set => Set(value); }
    public string            ID          { get => (string           )Get()!; set => Set(value); }
    public string            Ver         { get => (string           )Get()!; set => Set(value); }
    public string            FullArgs    { get => (string           )Get()!; set => Set(value); }

    public string DebuggerDisplay => Get<string>()!;
}
