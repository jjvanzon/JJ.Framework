namespace JJ.Framework.Compilation.Core;

internal class DotNetCommandInfo
{
    public DotNetCommandEnum CommandEnum { get; set; }
    public string Command { get ; set; } = "";
    public bool IsRebuild { get; set; }
    public string PackageID { get; set; } = "";
    public string PackageVer { get; set; } = "";
    public string Args { get; set; } = "";
}

