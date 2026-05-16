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
