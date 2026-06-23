// ReSharper disable HeuristicUnreachableCode
namespace JJ.Framework.Compilation.Core.Formatters;

internal static class DotNetCmdFormatter
{
    public const string REBUILD_ARG_MS_BUILD = "/t:Rebuild";
    public const string REBUILD_ARG_DOT_NET = "--no-incremental";

    public static string FormatArgs(DotNetArgs args, DotNetOptions opt)
    {
        string formattedCommandAndFile  = TryFormatCommandAndFile (args.CommandEnum, args.Command, opt.File);
        string formattedPackageID       = TryFormatPackageID      (args.ID);
        string formattedPackageVer      = TryFormatPackageVer     (args.Ver);
        string formattedBuildConf       = TryFormatBuildConf      (opt.BuildConf,       args.CommandEnum);
        string formattedRebuildArg      = TryFormatRebuildArg     (args.IsRebuild,      args.CommandEnum);
        string formattedVerbosity       = TryFormatVerbosity      (opt.Verbosity,       args.CommandEnum);
        string formattedParallelRestore = TryFormatParallelRestore(opt.ParallelRestore, args.CommandEnum);
        string formattedNodeReuse       = TryFormatNodeReuse      (opt.NodeReuse,       args.CommandEnum);
        string formattedBinLog          = TryFormatBinLog         (opt.BinLog,          args.CommandEnum);
        string formattedAutoRestore     = TryFormatAutoRestore    (opt.AutoRestore,     args.CommandEnum);
        string[] elements = 
        [
            formattedCommandAndFile, 
            formattedPackageID, formattedPackageVer,
            formattedBuildConf, formattedRebuildArg, formattedVerbosity, 
            formattedParallelRestore, 
            formattedNodeReuse, formattedBinLog, 
            opt.Args, args.Args, formattedAutoRestore // Auto-restore at the end makes `add package` work.
        ];
        string ret = Join(" ", elements.Where(FilledIn));
        return ret; 
    }

    /// <inheritdoc cref="_tryformatcommandandfile" />
    private static string TryFormatCommandAndFile(DotNetCommandEnum commandEnum, string command, string file)
    {
        // No file? Just return command.
        if (!Has(file)) return command;

        // `add package`: likes the --project switch.
        if (commandEnum == installpackage)
        {
            return FormatInstallPackage(command, file);
        }

        if (IsRemovePackage(command))
        {
            return FormatRemovePackage(command, file);
        }

        if (IsPackageRemove(command))
        {
            return FormatPackageRemove(command, file);
        }

        // Any other command: just concat file.
        return $"{command} {FormatFile(file)}";
    }

    private static string FormatInstallPackage(string command, string file) => $"{command} --project {FormatFile(file)}";

    private static bool IsPackageRemove(string command) => command.TrimStart().StartsWith("package remove", OrdinalIgnoreCase);

    private static string FormatPackageRemove (string command, string file) => $"{command} --project {FormatFile(file)}";

    private static bool IsRemovePackage(string command) => command.TrimStart().StartsWith("remove package", OrdinalIgnoreCase);

    /// <inheritdoc cref="_formatremovepackage" />
    private static string FormatRemovePackage(string command, string file)
    {
        string suffix = command.TrimStart().ToLower().CutLeft("remove package");
        return $"remove {FormatFile(file)} package" + suffix;
    }

    private static string FormatFile(string file)
    {
        if (!Has(file)) return file;
        return '"' + file + '"';
    }

    private static string TryFormatPackageID(string id)
    {
        if (id.IsNully()) return "";
        return $"{id}";
    }

    private static string TryFormatPackageVer(string ver)
    {
        if (ver.IsNully()) return "";
        return $"--version {ver}";
    }
    
    private static string TryFormatBuildConf(string buildConf, DotNetCommandEnum commandEnum)
    {
        if (!Has(buildConf)) return "";
        if (commandEnum is build or rebuild) return $"-c {buildConf}";
        if (commandEnum is msbuild or msrebuild) return $"/p:Configuration={buildConf}";
        return "";
    }

    private static string TryFormatRebuildArg(bool isRebuild, DotNetCommandEnum commandEnum)
    {
        if (!isRebuild) return "";
        if (commandEnum is build or rebuild) return REBUILD_ARG_DOT_NET;
        if (commandEnum is msbuild or msrebuild) return REBUILD_ARG_MS_BUILD;
        return "";
    }

    private static string TryFormatAutoRestore(bool autoRestore, DotNetCommandEnum commandEnum)
    {
        if (commandEnum is build or rebuild) return autoRestore ? "" : "--no-restore";
        if (commandEnum is msbuild or msrebuild) return autoRestore ? "-restore" : "";
        return "";
    }

    private static string TryFormatParallelRestore(bool parallelRestore, DotNetCommandEnum commandEnum)
    {
        if (parallelRestore) return "";
        if (commandEnum != restore) return "";
        return "--disable-parallel";
    }

    private static string TryFormatVerbosity(DotNetVerbosity verbosity, DotNetCommandEnum commandEnum)
    {
        if (verbosity == DefaultOptions.Verbosity) return "";
        if (commandEnum is build or rebuild) return $"--verbosity {verbosity}";
        if (commandEnum is msbuild or msrebuild) return $"-verbosity:{verbosity}";
        return "";
    }

    private static string TryFormatBinLog(string binLogFile, DotNetCommandEnum commandEnum)
    {
        if (binLogFile.IsNully()) 
        {
            return "";
        }

        if (commandEnum is not (build or rebuild or msbuild or msrebuild)) 
        {
            return "";
        }
           
        return $"-bl:\"{binLogFile}\"";
    }

    private static string TryFormatNodeReuse(bool nodeReuse, DotNetCommandEnum commandEnum)
    {
        // Assumed true by default.
        if (nodeReuse) return "";

        if (commandEnum is build or rebuild or msbuild or msrebuild)
        {
            return "--nodereuse:false";
        }

        return "";
    }
}
