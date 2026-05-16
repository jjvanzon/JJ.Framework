namespace JJ.Framework.Compilation.Core;

internal static class DotNetLogger
{
    private static readonly string e = NewLine;

    public static void Log(DotNetArgs args, DotNetOptions opt, string fullArgs)
    {
        if (opt.Log == NullLog) return;
        string message = GetMessage(opt.Verbosity, args, fullArgs);
        if (Has(message)) opt.Log(message);
    }

    private static string GetMessage(DotNetVerbosity verbosity, DotNetArgs args, string fullArgs) => verbosity switch
    {
        Quiet   => "",
        Minimal => GetMessageMinimal(args),
        Normal  => GetMessageNormal(args, fullArgs),
        _       => GetMessageDetailed(args, fullArgs)
    };

    private static string GetMessageMinimal(DotNetArgs args)
        => FormatCommand(args.CommandEnum) + FormatArgs(args.Args);

    private static string GetMessageNormal(DotNetArgs args, string fullArgs) 
        => $"{FormatCommand(args.CommandEnum)}:" + e +
           $"dotnet {fullArgs}" + e
           ;

    private static string GetMessageDetailed(DotNetArgs args, string fullArgs) 
        => e + 
           FormatCommand(args.CommandEnum) + e + 
           "-----" + e + 
           $"dotnet {fullArgs}" + e
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
