namespace JJ.Framework.Compilation.Core;

internal static class DotNetLogger
{
    public static void Log(DotNetCommandInfo info, DotNetOptions opt)
    {
        if (opt.Log == NullLog) return;
        if (opt.Verbosity == Quiet) return;
        string message = GetMessage(info);
        if (Has(message)) opt.Log(message);
    }

    private static string GetMessage(DotNetCommandInfo info) 
        => info.CommandEnum switch
        {
            build   or msbuild   => "Build" + FormatArgs(info.Args),
            rebuild or msrebuild => "Rebuild" + FormatArgs(info.Args),
            restore              => "Restore",
            installpackage       => "Install package",
            uninstallpackage     => "Uninstall package",
            _ => ""
        };

    private static string FormatArgs(string args)
    {
        args = StripReArg(args);
        return Has(args) ? " with " + args : "";
    }
}
