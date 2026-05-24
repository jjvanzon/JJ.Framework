namespace JJ.Framework.Compilation.Core;

internal static partial class DiagnosticsFormatter
{
    public static string Stringify(DotNetOptions opt)
    {
        string descriptor = Descriptor(opt);
        string sep = Has(descriptor) ? " " : "";
        return nameof(DotNetOptions) + sep + descriptor;
    }

    public static string DebuggerDisplay(DotNetOptions opt)
    {
        var descriptor = Descriptor(opt);
        descriptor = descriptor.Replace(@"""", "'").Replace(@"\", "/");
        string sep = Has(descriptor) ? " " : "";
        return "{" + nameof(DotNetOptions) + sep + descriptor + "}";
    }

    public static string Descriptor(DotNetOptions opt)
    {
        if (opt == default) return "default";
        if (opt == DefaultOptions) return "default";

        string[] elements = 
        [
            FormatBuildConf(opt), 
            FormatRestore(opt), 
            FormatLogOptions(opt), 
            FormatTimeOut(opt), 
            FormatFileOptions(opt)
        ];

        var descriptor = Join(" | ", elements.Where(FilledIn));

        descriptor = Coalesce(descriptor, "default");

        return descriptor;
    }

    // BuildConf

    private static string FormatBuildConf(DotNetOptions opt) => FormatBuildConf(opt.BuildConf);
    private static string FormatBuildConf(string buildConf)
    {
        return Has(buildConf) ? '"' + buildConf + '"' : "";
    }

    // Restore

    private static string FormatRestore(DotNetOptions opt) => FormatRestore(opt.AutoRestore, opt.ParallelRestore);
    private static string FormatRestore(bool autoRestore, bool parallelRestore)
    {
        if (!HasRestore(autoRestore, parallelRestore)) 
        {
            return "";
        }

        string[] elements = 
        [
            "Restore:", 
            autoRestore ? "Auto" : "", 
            parallelRestore ? "Parallel" : "" 
        ];

        return Join(" ", elements.Where(FilledIn));
    }

    private static bool HasRestore(bool autoRestore, bool parallelRestore) => autoRestore || parallelRestore;

    // Log

    private static string FormatLogOptions(DotNetOptions opt) => FormatLogOptions(opt.Verbosity, opt.Log);
    private static string FormatLogOptions(DotNetVerbosity verbosity, Action<string>? log)
    {
        if (!HasLog(log)) return "";
        if (verbosity == Normal) return "Log";
        return $"Log {verbosity}";
    }

    private static bool HasLog(Action<string>? log) => log != null && log != NullLog;

    // TimeOut

    private static string FormatTimeOut(DotNetOptions opt) => FormatTimeOut(opt.TimeOutSec);
    private static string FormatTimeOut(int timeOutSec)
    {
        return HasTimeOut(timeOutSec) ? $"Timeout: {timeOutSec}s" : "";
    }

    private static bool HasTimeOut(int timeOutSec) => timeOutSec != 0 && timeOutSec != DEFAULT_TIME_OUT_SEC;

    // File Options

    private const int LONG_PATH_LENGTH = 20;

    private static string FormatFileOptions(DotNetOptions opt) => FormatFileOptions(opt.File, opt.Args, opt.Dir);
    private static string FormatFileOptions(string? file, string? args, string? dir)
    {
        bool hasSep1 = Has(args) && Has(file);
        bool hasSep2 = (Has(args) || Has(file)) && Has(dir);

        bool filePathIsLong = file?.Length > LONG_PATH_LENGTH;
        string formattedDir = FormatDir(dir);

        if (filePathIsLong)
        {
            string sep1 = hasSep1 ? " | " : "";
            string sep2 = hasSep2 ? " | " : "";
            return args + sep1 + file + sep2 + formattedDir;
        }
        else
        { 
            string sep1 = hasSep1 ? " " : "";
            string sep2 = hasSep2 ? " | " : "";
            return file + sep1 + args + sep2 + formattedDir;
        }
    }

    private static string FormatDir(string? dir) => Has(dir) ? "Dir: " + '"' + dir + '"' : "";
}
