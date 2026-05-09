namespace JJ.Framework.Compilation.Core;

internal static class DotNetFormatter
{
    public const string REBUILD_ARG_MS_BUILD = "/t:Rebuild";
    public const string REBUILD_ARG_DOT_NET = "--no-incremental";


    public static string FormatArgs(DotNetInfo info, DotNetOptions opt)
    {
        string formattedFile        = FormatFile(opt.File);
        string formattedAutoRestore = TryFormatAutoRestore(opt.AutoRestore, info.CommandEnum);
        string formattedBuildConf   = TryFormatBuildConf  (opt.BuildConf,   info.CommandEnum);
        string formattedVerbosity   = TryFormatVerbosity  (opt.Verbosity,   info.CommandEnum);
        string formattedRebuildArg  = TryFormatRebuildArg (info.IsRebuild,  info.CommandEnum);
        string formattedPackageID   = TryFormatPackageID  (info.ID);
        string formattedPackageVer  = TryFormatPackageVer (info.Ver);
        string[] elements = 
        [
            info.Command, formattedFile, 
            formattedBuildConf, formattedRebuildArg, formattedVerbosity, 
            formattedPackageID, formattedPackageVer,
            opt.Args, info.Args, formattedAutoRestore // HACK: auto-restore put at the end makes `add package` work.
        ]; 
        string ret = Join(" ", elements.Where(FilledIn));
        return ret; 
    }

    private static string FormatFile(string file) => Has(file) ? '"' + file + '"' : "";

    private static string TryFormatAutoRestore(bool autoRestore, DotNetCommandEnum commandEnum)
    {
        if (commandEnum is build or rebuild) return autoRestore ? "" : "--no-restore";
        if (commandEnum is msbuild or msrebuild) return autoRestore ? "-restore" : "";
        return "";
    }

    private static string TryFormatBuildConf(string buildConf, DotNetCommandEnum commandEnum)
    {
        if (!Has(buildConf)) return "";
        if (commandEnum is build or rebuild) return $"-c {buildConf}";
        if (commandEnum is msbuild or msrebuild) return $"/p:Configuration={buildConf}";
        return "";
    }

    private static string TryFormatVerbosity(DotNetVerbosity verbosity, DotNetCommandEnum commandEnum)
    {
        if (verbosity == default) return "";
        if (commandEnum is build or rebuild) return $"--verbosity {verbosity}";
        if (commandEnum is msbuild or msrebuild) return $"-verbosity:{verbosity}";
        return "";
    }

    private static string TryFormatRebuildArg(bool isRebuild, DotNetCommandEnum commandEnum)
    {
        if (!isRebuild) return "";
        if (commandEnum is build or rebuild) return REBUILD_ARG_DOT_NET;
        if (commandEnum is msbuild or msrebuild) return REBUILD_ARG_MS_BUILD;
        return "";
    }

    private static string TryFormatPackageID(string id)
    {
        if (id.IsNully()) return "";
        return $"package {id}";
    }

    private static string TryFormatPackageVer(string ver)
    {
        if (ver.IsNully()) return "";
        return $"--version {ver}";
    }

    public static string StripReArg(string args) 
        => args.Replace(REBUILD_ARG_DOT_NET, "")
               .Replace(REBUILD_ARG_MS_BUILD, "");

    //public static string PackArg(string id) => $"package {id}";
    //public static string PackArg(string id, string ver) => $"package {id} --version {ver}";
}
