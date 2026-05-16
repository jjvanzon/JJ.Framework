namespace JJ.Framework.Compilation.Core;

public class DotNetArgs
{
    public DotNetArgs() { }
    public DotNetArgs(DotNetCommandEnum commandEnum) => CommandEnum = commandEnum;
    public DotNetArgs(string command) => Command = command;

    public DotNetCommandEnum CommandEnum { get; set; }
    public string            Command     { get; set; } = "";
    public string            ID          { get; set; } = "";
    public string            Ver         { get; set; } = "";
    public string            Args        { get; set; } = "";
    public bool              IsRebuild   { get; set; }
    public string            FullArgs    { get; internal set; } = "";
}

