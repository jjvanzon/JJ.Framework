namespace JJ.Framework.Compilation.Core;

internal static class DotNetLogger
{
    private static readonly string e = NewLine;

    public static void Log(DotNetArgs args, DotNetOptions opt)
    {
        if (opt.Log == NullLog) return;
        string message = GetMessage(opt.Verbosity, args);
        if (Has(message)) opt.Log(message);
    }

    public static void LogOutputIfNeeded(DotNetResult result)
    {
        if (!result.Opt.Verbosity.In(Diagnostic, Detailed)) return;
        if (!Has(result.OutputText)) return;

        // HACK: This blows up my CI if I enable Verbose or Detailed logging (but I need that for binlogs).
        //result.Opt.Log(result.OutputText);
    }

    private static string GetMessage(DotNetVerbosity verbosity, DotNetArgs args) => verbosity switch
    {
        Quiet   => "",
        Minimal => GetMessageMinimal(args),
        Normal  => GetMessageNormal(args),
        _       => GetMessageDetailed(args)
    };

    private static string GetMessageMinimal(DotNetArgs args)
        => FormatCommand(args.CommandEnum) + FormatArgs(args.Args);

    private static string GetMessageNormal(DotNetArgs args) 
        => $"{FormatCommand(args.CommandEnum)}:" + e +
           $"dotnet {args.FullArgs}" + e
           ;

    private static string GetMessageDetailed(DotNetArgs args) 
        => e + 
           FormatCommand(args.CommandEnum) + e + 
           "-----" + e + 
           $"dotnet {args.FullArgs}" + e
           ;

    private static string FormatCommand(DotNetCommandEnum command) => command switch
    {
        build   or msbuild   => "Build",
        rebuild or msrebuild => "Rebuild",
        restore              => "Restore",
        installpackage       => "Install package",
        uninstallpackage     => "Uninstall package",
        _ => ""
    };

    private static string FormatArgs(string args) => Has(args) ? $" with {args}" : "";
}
