namespace JJ.Framework.Compilation.Core;

internal static class DotNetLogger
{
    private static readonly string e = NewLine;

    public static void Log(DotNetInfo info, string fullArgs, DotNetOptions opt)
    {
        if (opt.Log == NullLog) return;
        string message = GetMessage(opt.Verbosity, info, fullArgs);
        if (Has(message)) opt.Log(message);
    }

    private static string GetMessage(DotNetVerbosity verbosity, DotNetInfo info, string fullArgs)
    {
        if (verbosity == Quiet) return "";
        if (verbosity == Minimal) return GetMessageMinimal(info);
        if (verbosity == Normal) return GetMessageNormal(info, fullArgs);
        return GetMessageDetailed(info, fullArgs);
    }

    private static string GetMessageMinimal(DotNetInfo info)
        => FormatCommand(info.CommandEnum) + FormatArgs(info.Args);

    private static string GetMessageNormal(DotNetInfo info, string fullArgs) 
        => $"{FormatCommand(info.CommandEnum)}:" + e +
           $"dotnet {fullArgs}" + e
           ;

    private static string GetMessageDetailed(DotNetInfo info, string fullArgs) 
        => e + 
           FormatCommand(info.CommandEnum) + e + 
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
