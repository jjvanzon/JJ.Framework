namespace JJ.Framework.Compilation.Core;

internal static class DotNetFormatter
{
    // TODO: Sanitization

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

    public static string Re(string command)
    {
        if (command.Is("build")) return "--no-incremental";
        if (command.Is("msbuild")) return "/t:Rebuild";
        return "";
    }

    public static bool IsRebuild(string args)
    {
        var rebuildArg = Re("msbuild");
        return args.Contains(rebuildArg, OrdinalIgnoreCase);
    }
}
