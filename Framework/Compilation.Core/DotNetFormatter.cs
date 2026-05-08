namespace JJ.Framework.Compilation.Core;

internal static class DotNetFormatter
{
    public static string FormatArgs(DotNetCommandInfo info, DotNetOptions opt)
    {
        string formattedFile      = FormatFile(opt.File);
        string formattedRestore   = TryFormatAutoRestore(opt.AutoRestore, info.CommandEnum);
        string formattedBuildConf = TryFormatBuildConf  (opt.BuildConf,   info.CommandEnum);
        string formattedVerbosity = TryFormatVerbosity  (opt.Verbosity,   info.CommandEnum);
        string[] elements = [ info.Command, formattedFile, formattedBuildConf, formattedVerbosity, opt.Args, info.Args, formattedRestore ]; // HACK: auto-restore put at the end makes `add package` work.
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

    public static string PackArg(string id) => $"package {id}";
    public static string PackArg(string id, string ver) => $"package {id} --version {ver}";

    public const string REBUILD_ARG_MS_BUILD = "/t:Rebuild";
    public const string REBUILD_ARG_DOT_NET = "--no-incremental";

    public static string ReArg(string command)
    {
        if (command.Is("build"  )) return REBUILD_ARG_DOT_NET;
        if (command.Is("msbuild")) return REBUILD_ARG_MS_BUILD;
        return "";
    }

    public static string StripReArg(string args) 
        => args.Replace(REBUILD_ARG_DOT_NET, "")
               .Replace(REBUILD_ARG_MS_BUILD, "");

    // Enum Helpers

    public static string ReArg(DotNetCommandEnum command)
    {
        if (command == rebuild  ) return REBUILD_ARG_DOT_NET;
        if (command == msrebuild) return REBUILD_ARG_MS_BUILD;
        return "";
    }

    //public static bool IsMSBuild(DotNetCommand command) 
    //    => command == msbuild || command == msrebuild;

    //public static string Re(bool re)
    //{
    //    if (re)
    //    if (command.Is("build")) return "--no-incremental";
    //    if (command.Is("msbuild")) return "/t:Rebuild";
    //    return "";
    //}

    //public static bool IsRebuild(DotNetCommand command)
    //{
    //    if (command == rebuild) return true;
    //    if (command == msrebuild) return true;
    //    return false;
    //}

    public static bool IsRebuild(string command, string args)
    {
        var rebuildArg = ReArg(command);
        return args.Contains(rebuildArg, OrdinalIgnoreCase);
    }
}
