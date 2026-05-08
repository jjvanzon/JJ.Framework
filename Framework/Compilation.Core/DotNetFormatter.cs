namespace JJ.Framework.Compilation.Core;

internal static class DotNetFormatter
{
    public static string FormatArgs(DotNetCommandInfo info, DotNetOptions opt)
    {
        string formattedFile      = FormatFile(opt.File);
        string formattedRestore   = FormatAutoRestore(opt.AutoRestore, info.Command);
        string formattedBuildConf = FormatBuildConf(opt.BuildConf, info.Command);
        string formattedVerbosity = FormatVerbosity(opt.Verbosity, info.Command);
        string[] elements = [ info.Command, formattedFile, formattedBuildConf, formattedVerbosity, opt.Args, info.Args, formattedRestore ]; // HACK: auto-restore put at the end makes `add package` work.
        string ret = Join(" ", elements.Where(FilledIn));
        return ret; 
    }

    private static string FormatFile(string file) => Has(file) ? '"' + file + '"' : "";

    private static string FormatAutoRestore(bool autoRestore, string command)
    {
        if (command.Is("add"))     return ""; // Needed?
        if (command.Is("restore")) return "";
        if (command.Is("remove"))  return ""; // Wouldn't this exclusion only apply to packages instead of removing other things?
        if (command.Is("msbuild")) return autoRestore ? "-restore" : "";
        return autoRestore ? "" : "--no-restore";
    }

    private static string FormatBuildConf(string buildConf, string command)
    {
        if (!Has(buildConf)) return "";
        if (command.Is("build")) return $"-c {buildConf}";
        if (command.Is("msbuild")) return $"/p:Configuration={buildConf}";
        return "";
    }

    private static string FormatVerbosity(DotNetVerbosity verbosity, string command)
    {
        if (verbosity == default) return "";
        if (command.Is("build")) return $"--verbosity {verbosity}";
        if (command.Is("msbuild")) return $"-verbosity:{verbosity}";
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

    public static DotNetCommandEnum TryGetCommandEnum(string command, string args)
    {
        return TryGetCommandEnum(command, IsRebuild(command, args));
    }

    public static DotNetCommandEnum TryGetCommandEnum(string command, bool isRebuild)
    {
        if (command.Is("build"))   return isRebuild ? rebuild : build;
        if (command.Is("msbuild")) return isRebuild ? msrebuild : msbuild;
        if (command.Is("restore")) return restore;
        // TODO: Assumptive (but true, for now?)
        if (command.Is("add"))     return installpackage; 
        if (command.Is("remove"))  return uninstallpackage;
        return default;
        
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
