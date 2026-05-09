namespace JJ.Framework.Compilation.Core;

internal class DotNetInfo
{
    public DotNetInfo() { }
    public DotNetInfo(DotNetCommandEnum commandEnum) => CommandEnum = commandEnum;
    public DotNetInfo(string command) => Command = command;

    public DotNetCommandEnum CommandEnum { get; set; }
    public string Command { get ; set; } = "";
    public bool IsRebuild { get; set; }
    public string PackageID { get; set; } = "";
    public string PackageVer { get; set; } = "";
    public string Args { get; set; } = "";
}

