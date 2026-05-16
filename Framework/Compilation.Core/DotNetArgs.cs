namespace JJ.Framework.Compilation.Core;

public readonly record struct DotNetArgs
{
    public DotNetArgs() { }
    public DotNetArgs(DotNetCommandEnum commandEnum) => CommandEnum = commandEnum;
    public DotNetArgs(string command) => Command = command;

    public DotNetCommandEnum CommandEnum { get; init; }
    // TODO: Rename to DotNetCommand (command enum rebuild maps to command build, which sounds ambiguous
    public string            Command     { get; init; } = "";
    public string            ID          { get; init; } = "";
    public string            Ver         { get; init; } = "";
    // TODO: Rename to ExtraArgs
    public string            Args        { get; init; } = "";
    public bool              IsRebuild   { get; init; }
    public string            FullArgs    { get; internal init; } = "";
}

