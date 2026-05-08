namespace JJ.Framework.Compilation.Core;

internal static class DotNetLogger
{
    public static void LogCommand(string command, string args, DotNetOptions opt)
    {
        if (opt.Log == NullLog) return;
        if (opt.Verbosity == Quiet) return;
        opt.Log(GetLogMessage(command, args));
    }

    private static string GetLogMessage(string command, string args) 
        => GetCommandEnum(command, args) switch
        {
            build   or msbuild   => "Build" + FormatArgsForLog(args),
            rebuild or msrebuild => "Rebuild" + FormatArgsForLog(args),
            restore              => "Restore",
            installpackage       => "Install package",
            uninstallpackage     => "Uninstall package",
            _ => ""
        };

    private static string FormatArgsForLog(string args)
    {
        args = StripReArg(args);
        return Has(args) ? " with " + args : "";
    }
}
