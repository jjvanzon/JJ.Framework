namespace JJ.Framework.Compilation.Core;

internal static class DotNetLogger
{
    public static void Log(DotNetCommandInfo info, DotNetOptions opt)
    {
        if (opt.Log == NullLog) return;
        if (opt.Verbosity == Quiet) return;
        string message = GetMessage(info.Command, info.Args);
        if (Has(message)) opt.Log(message);
    }

    private static string GetMessage(string command, string args) 
        => TryGetCommandEnum(command, args) switch
        {
            build   or msbuild   => "Build" + FormatArgs(args),
            rebuild or msrebuild => "Rebuild" + FormatArgs(args),
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
