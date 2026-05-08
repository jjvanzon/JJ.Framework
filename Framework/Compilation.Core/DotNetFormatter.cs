namespace JJ.Framework.Compilation.Core;

internal static class DotNetFormatter
{
    // TODO: Sanitization

    public static string FormatCommand(DotNetCommand command) => command switch
    {
        build or rebuild => "build",
        msbuild or msrebuild => "msbuild",
        restore => "restore",
        installpackage => "add",
        uninstallpackage => "remove",
        _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
    };

    public static string FormatArgs(string command, string args, DotNetOptions opt)
    {
        ThrowIf(IsNullOrWhiteSpace(command));
        string formattedFile      = FormatFile(opt.File);
        string formattedRestore   = FormatAutoRestore(opt.AutoRestore, command);
        string formattedBuildConf = FormatBuildConf(opt.BuildConf, command);
        string formattedVerbosity = FormatVerbosity(opt.Verbosity, command);
        string[] elements = [ command, formattedFile, formattedBuildConf, formattedVerbosity, opt.Args, args, formattedRestore ]; // HACK: auto-restore put at the end makes `add package` work.
        string ret = Join(" ", elements.Where(FilledIn));
        return ret; 
    }

    public static string FormatFile(string file) => Has(file) ? '"' + file + '"' : "";

    public static string FormatAutoRestore(bool autoRestore, string command)
    {
        if (command.Is("add"))     return ""; // Needed?
        if (command.Is("restore")) return "";
        if (command.Is("remove"))  return ""; // Wouldn't this exclusion only apply to packages instead of removing other things?
        if (command.Is("msbuild")) return autoRestore ? "-restore" : "";
        return autoRestore ? "" : "--no-restore";
    }

    public static string FormatBuildConf(string buildConf, string command)
    {
        if (!Has(buildConf)) return "";
        if (command.Is("build")) return $"-c {buildConf}";
        if (command.Is("msbuild")) return $"/p:Configuration={buildConf}";
        return "";
    }
    
    public static string FormatVerbosity(DotNetVerbosity verbosity, string command)
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

    public static string ReArg(DotNetCommand command)
    {
        if (command == rebuild  ) return REBUILD_ARG_DOT_NET;
        if (command == msrebuild) return REBUILD_ARG_MS_BUILD;
        return "";
    }

    public static DotNetCommand GetCommandEnum(string command, string args)
    {
        DotNetCommand commandEnum = TryGetCommandEnum(command, args);
        if (!Has(commandEnum))
        {
            throw new Exception($"Cannot derive DotNetCommand enum from {new { command, args }}");
        }
        return commandEnum;
    }

    public static DotNetCommand TryGetCommandEnum(string command, string args)
    {
        if (command.Is("build"))   return IsRebuild(command, args) ? rebuild : build;
        if (command.Is("msbuild")) return IsRebuild(command, args) ? msrebuild : msbuild;
        if (command.Is("restore")) return restore;
        // Assumptive (but true, for now?)
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
