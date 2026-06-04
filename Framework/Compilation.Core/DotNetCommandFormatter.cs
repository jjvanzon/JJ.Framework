// ReSharper disable HeuristicUnreachableCode
namespace JJ.Framework.Compilation.Core;

internal static class DotNetCommandFormatter
{
    public const string REBUILD_ARG_MS_BUILD = "/t:Rebuild";
    public const string REBUILD_ARG_DOT_NET = "--no-incremental";

    public static string FormatArgs(DotNetArgs args, DotNetOptions opt)
    {
        string formattedCommandAndFile  = TryFormatCommandAndFile (args, opt);
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

    /// <summary>
    /// NOTE:
    /// We use <c>remove package</c> instead of <c>package remove</c> for backward compatibility prior to .NET 10.
    /// For <c>dotnet remove package</c>, we need to squish the <c>File</c> arg in between 
    /// <c>remove</c> and <c>package</c> e.g., <c>remove Temp.csproj package</c>.
    /// </summary>
    private static string TryFormatCommandAndFile(DotNetArgs args, DotNetOptions opt)
    {
        DotNetCommandEnum commandEnum = args.CommandEnum;
        string command = args.Command;
        string file = opt.File;

        // No file? Just return command.
        if (!Has(file)) return command;
        
        string formattedFile = '"' + file + '"';

        // `remove package`: special case: squish file in between keywords. 
        if (commandEnum == uninstallpackage)
        {
            return $"remove {formattedFile} package ";
        }

        // `add package`: likes the --project switch.
        if (commandEnum == installpackage)
        {
            return $"{command} --project {formattedFile}";
        }

        // Any other command: just concat file.
        return $"{command} {formattedFile}";
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
        return $"{id}";
    }

    private static string TryFormatPackageVer(string ver)
    {
        if (ver.IsNully()) return "";
        return $"--version {ver}";
    }
}
