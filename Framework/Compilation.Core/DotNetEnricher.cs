namespace JJ.Framework.Compilation.Core;

internal static class DotNetEnricher
{
    public static void Enrich(DotNetArgs args)
    {
        args.IsRebuild   = args.IsRebuild || 
                           IsRebuild(args.CommandEnum) || 
                           IsRebuild(args.Command, args.Args);

        args.Command     = Has(args.Command) ? 
                           args.Command : 
                           FormatCommand(args.CommandEnum);

        args.CommandEnum = Has(args.CommandEnum) ? 
                           args.CommandEnum : 
                           TryGetCommandEnum(args.Command, args.IsRebuild);
    }

    public static string FormatCommand(DotNetCommandEnum val) => val switch
    {
        build or rebuild => "build",
        msbuild or msrebuild => "msbuild",
        restore => "restore",
        installpackage => "package add",
        uninstallpackage => "package remove",
        _ => ""
    };

    public static DotNetCommandEnum TryGetCommandEnum(string command, bool isRebuild)
    {
        if (command.Is("build"))   return isRebuild ? rebuild : build;
        if (command.Is("msbuild")) return isRebuild ? msrebuild : msbuild;
        if (command.Is("restore")) return restore;
        if (command.Is("package add"))     return installpackage; 
        if (command.Is("package remove"))  return uninstallpackage;
        return default;
    }

    private static bool IsRebuild(DotNetCommandEnum command)
        => command is rebuild or msrebuild;

    private static bool IsRebuild(string command, string args)
    {
        var rebuildArg = ReArg(command);
        var isRebuild = Has(rebuildArg) && args.Contains(rebuildArg, OrdinalIgnoreCase);
        return isRebuild;
    }

    private static string ReArg(string command)
    {
        if (command.Is("build"  )) return REBUILD_ARG_DOT_NET;
        if (command.Is("msbuild")) return REBUILD_ARG_MS_BUILD;
        return "";
    }
}
