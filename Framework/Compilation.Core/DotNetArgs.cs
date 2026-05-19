namespace JJ.Framework.Compilation.Core;

public class DotNetArgs
{
    public override string ToString() => DebuggerDisplay(this);

    internal DotNetArgs() { }
    internal DotNetArgs(DotNetCommandEnum commandEnum) => CommandEnum = commandEnum;
    internal DotNetArgs(string command) => Command = command;

    public DotNetCommandEnum CommandEnum { get; internal set; }
    public string            Command     { get; internal set; } = "";
    public string            ID          { get; internal set; } = "";
    public string            Ver         { get; internal set; } = "";
    public string            Args        { get; internal set; } = "";
    public bool              IsRebuild   { get; internal set; }
    public string            FullArgs    { get; internal set; } = "";
}

