namespace JJ.Framework.Compilation.Core;
public record struct DotNetCommandInfo
{
    public DotNetCommand CommandEnum { get; init; }
    public string Command { get ; init; }
    public bool IsRebuild { get; init; }
    public string PackageID { get; init; }
    public string PackageVer { get; init; }
    public string Args { get; init; }
}

