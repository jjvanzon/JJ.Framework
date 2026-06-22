namespace JJ.Framework.Compilation.Core.Primitives;

/// <inheritdoc cref="_dotnetargs" />
[DebuggerDisplay("{DebuggerDisplay}")]
public class DotNetArgs
{
    private string DebuggerDisplay => DebuggerDisplay(this);

    /// <inheritdoc cref="_tostring" />
    public override string ToString() => Stringify(this);

    /// <inheritdoc cref="_dotnetargs" />
    internal DotNetArgs() { }
    /// <inheritdoc cref="_dotnetargs" />
    internal DotNetArgs(DotNetCommandEnum commandEnum) => CommandEnum = commandEnum;
    /// <inheritdoc cref="_dotnetargs" />
    internal DotNetArgs(string command) => Command = command;

    /// <inheritdoc cref="_dotnetcommandenum" />
    public DotNetCommandEnum CommandEnum { get; internal set; }
    /// <inheritdoc cref="_exe" />
    public string            Command     { get; internal set; } = "";
    /// <inheritdoc cref="_installpackage" />
    public string            ID          { get; internal set; } = "";
    /// <inheritdoc cref="_installpackage" />
    public string            Ver         { get; internal set; } = "";
    /// <inheritdoc cref="_args" />
    public string            Args        { get; internal set; } = "";
    /// <inheritdoc cref="_rebuild" />
    public bool              IsRebuild   { get; internal set; }
    /// <inheritdoc cref="_exe" />
    public string            FullArgs    { get; internal set; } = "";
}

