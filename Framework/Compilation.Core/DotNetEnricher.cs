namespace JJ.Framework.Compilation.Core;

internal static class DotNetEnricher
{
    public static void Enrich(DotNetInfo info)
    {
        info.IsRebuild   = info.IsRebuild || IsRebuild(info.CommandEnum) || IsRebuild(info.Command, info.Args);
        info.Command     = Has(info.Command) ? info.Command : FormatCommand(info.CommandEnum);
        info.CommandEnum = Has(info.CommandEnum) ? info.CommandEnum : TryGetCommandEnum(info.Command, info.IsRebuild);
    }

    public static string FormatCommand(DotNetCommandEnum val) => val switch
    {
        build or rebuild => "build",
        msbuild or msrebuild => "msbuild",
        restore => "restore",
        installpackage => "add",
        uninstallpackage => "remove",
        _ => ""
    };

    //public static DotNetCommandEnum TryGetCommandEnum(string command, string args)
    //{
    //    return TryGetCommandEnum(command, IsRebuild(command, args));
    //}

    public static DotNetCommandEnum TryGetCommandEnum(string command, bool isRebuild)
    {
        if (command.Is("build"))   return isRebuild ? rebuild : build;
        if (command.Is("msbuild")) return isRebuild ? msrebuild : msbuild;
        if (command.Is("restore")) return restore;
        // TODO: Assumptive
        if (command.Is("add"))     return installpackage; 
        if (command.Is("remove"))  return uninstallpackage;
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
