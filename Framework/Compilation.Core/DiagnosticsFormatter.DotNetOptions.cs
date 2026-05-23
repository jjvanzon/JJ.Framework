namespace JJ.Framework.Compilation.Core;

internal static partial class DiagnosticsFormatter
{
    public static string DebuggerDisplay(DotNetOptions opt) 
        => nameof(DotNetOptions) + " " + Descriptor(opt);

    public static string Descriptor(DotNetOptions opt)
    {
        string formattedRestore     = FormatRestore(opt);
        string formattedLogOptions  = FormatLogOptions(opt);
        string formattedTimeOut     = FormatTimeOut(opt);
        string formattedFileOptions = FormatFileOptions(opt);
        string[] elements = [opt.BuildConf, formattedRestore, formattedLogOptions, formattedTimeOut, formattedFileOptions];
        return Join(" | ", elements.Where(FilledIn));
    }

    private static string FormatRestore(DotNetOptions opt)
        => FormatRestore(opt.AutoRestore, opt.ParallelRestore);

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

    private static bool HasRestore(bool autoRestore, bool parallelRestore)
        => autoRestore || parallelRestore;

    private static string FormatLogOptions(DotNetOptions opt)
        => FormatLogOptions(opt.Verbosity, opt.Log);
    
    private static string FormatLogOptions(DotNetVerbosity verbosity, Action<string>? log)
    {
        if (verbosity == Quiet || !HasLog(log)) return "";
        return $"Log: {verbosity}";
    }

    private static bool HasLog(Action<string>? log) => log != null && log != NullLog;

    private static string FormatTimeOut(DotNetOptions opt) 
        => FormatTimeOut(opt.TimeOutSec);

    private static string FormatTimeOut(int timeOutSec) 
        => HasTimeOut(timeOutSec) ? $"Timeout: {timeOutSec}s" : "";

    private static bool HasTimeOut(int timeOutSec)
       => timeOutSec != 0 && timeOutSec != DEFAULT_TIME_OUT_SEC;

    private static string FormatFileOptions(DotNetOptions opt)
        => FormatFileOptions(opt.File, opt.Args, opt.Dir);
    
    private static string FormatFileOptions(string file, string args, string dir)
    {
        // TODO: put args after file if file is not long (is usually when dir is filled in).
        string formattedDir = Has(dir) ? $"({dir})" : "";
        string[] elements = [ args, file, formattedDir ];
        return Join(" " , elements.Where(FilledIn));
    }
}
