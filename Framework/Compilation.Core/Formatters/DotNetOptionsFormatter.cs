namespace JJ.Framework.Compilation.Core.Formatters;

internal static class DotNetOptionsExtensions
{
    public static string Stringify(this DotNetOptions opt) => DotNetOptionsFormatter.Stringify(opt);
    public static string DebuggerDisplay(this DotNetOptions opt) => DotNetOptionsFormatter.DebuggerDisplay(opt);
    public static string Descriptor(this DotNetOptions opt, int? maxPathChars = null) => DotNetOptionsFormatter.Descriptor(opt, maxPathChars);
}

internal static class DotNetOptionsFormatter
{
    // Combined Descriptors

    public static string Stringify(DotNetOptions opt)
    {
        string descriptor = Descriptor(opt);
        string sep = Has(descriptor) ? " " : "";
        return nameof(DotNetOptions) + sep + descriptor;
    }

    public static string DebuggerDisplay(DotNetOptions opt)
    {
        var descriptor = Descriptor(opt, MAX_PATH_CHARS);
        descriptor = PrettifySeparators(descriptor);
        string sep = Has(descriptor) ? " " : "";
        return "{" + nameof(DotNetOptions) + sep + descriptor + "}";
    }

    public static string Descriptor(DotNetOptions opt, int? maxPathChars = null)
    {
        if (opt == default) return "default";
        if (opt == DefaultOptions) return "default";

        string[] elements = 
        [
            BuildConfDescriptor(opt), 
            RestoreDescriptor(opt), 
            LogDescriptor(opt), 
            TimeOutDescriptor(opt), 
            FileOptDescriptor(opt, maxPathChars)
        ];

        var descriptor = Join(" | ", elements.Where(FilledIn));

        descriptor = Coalesce(descriptor, "default");

        return descriptor;
    }

    // BuildConf

    public static string BuildConfDescriptor(DotNetOptions opt) => BuildConfDescriptor(opt.BuildConf);
    public static string BuildConfDescriptor(string buildConf)
    {
        return Has(buildConf) ? '"' + buildConf + '"' : "";
    }

    // Restore

    public static string RestoreDescriptor(DotNetOptions opt) => RestoreDescriptor(opt.AutoRestore, opt.ParallelRestore);
    public static string RestoreDescriptor(bool autoRestore, bool parallelRestore)
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

    public static string LogDescriptor(DotNetOptions opt) => LogDescriptor(opt.Verbosity, opt.LogAction);
    public static string LogDescriptor(DotNetVerbosity verbosity, Action<string>? log)
    {
        if (!HasLog(log)) return "";
        if (verbosity == Normal) return "Log";
        return $"Log {verbosity}";
    }

    private static bool HasLog(Action<string>? log) => log != null && log != NullAction;

    // TimeOut

    public static string TimeOutDescriptor(DotNetOptions opt) => TimeOutDescriptor(opt.TimeOutSec);
    public static string TimeOutDescriptor(int timeOutSec)
    {
        return HasTimeOut(timeOutSec) ? $"Timeout: {timeOutSec}s" : "";
    }

    private static bool HasTimeOut(int timeOutSec) => timeOutSec != 0 && timeOutSec != DefaultOptions.TimeOutSec;

    // File Options

    private const int LONG_PATH_LENGTH = 20;
    private const int MAX_PATH_CHARS = 40;

    public static string FileOptDescriptor(DotNetOptions opt, int? maxPathChars = null) => FileOptDescriptor(opt.File, opt.Args, opt.Dir, maxPathChars);
    public static string FileOptDescriptor(string? file, string? args, string? dir, int? maxPathChars = null)
    {
        bool hasSep1 = Has(args) && Has(file);
        bool hasSep2 = (Has(args) || Has(file)) && Has(dir);

        bool filePathIsLong = file?.Length > LONG_PATH_LENGTH;
        string formattedDir = DirDescriptor(dir, maxPathChars);
        string formattedFile = FileDescriptor(file, maxPathChars);

        if (filePathIsLong)
        {
            string sep1 = hasSep1 ? " | " : "";
            string sep2 = hasSep2 ? " | " : "";
            return args + sep1 + formattedFile + sep2 + formattedDir;
        }
        else
        { 
            string sep1 = hasSep1 ? " " : "";
            string sep2 = hasSep2 ? " | " : "";
            return formattedFile + sep1 + args + sep2 + formattedDir;
        }
    }

    public static string FileDescriptor(string? file, int? maxPathChars = null) => TruncatePath(file, maxPathChars);
    public static string DirDescriptor(string? dir, int? maxPathChars = null) => Has(dir) ? "Dir = " + TruncatePath(dir, maxPathChars) : "";

    private static string TruncatePath(string? path, int? maxPathChars = null)
    {
        path ??= "";
        if (maxPathChars == null) return path;
        if (path.Length <= maxPathChars) return path;
        return "... " + path.Right(maxPathChars.Value);
    }
}
