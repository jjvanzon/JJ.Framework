namespace JJ.Framework.Compilation.Core;

internal static class DotNetEnricher
{
    public static void Enrich(DotNetCommandInfo info)
    {
        info.Command     = Has(info.Command) ? info.Command : FormatCommand(info.CommandEnum);

        info.CommandEnum = info.CommandEnum
                               .Coalesce(TryGetCommandEnum(info.Command, info.IsRebuild))
                               .Coalesce(TryGetCommandEnum(info.Command, info.Args));

        info.IsRebuild   = Has(info.IsRebuild) ? info.IsRebuild : IsRebuild(info.Command, info.Args);
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

    public static DotNetCommandEnum TryGetCommandEnum(string command, string args)
    {
        return TryGetCommandEnum(command, IsRebuild(command, args));
    }

    public static DotNetCommandEnum TryGetCommandEnum(string command, bool isRebuild)
    {
        if (command.Is("build"))   return isRebuild ? rebuild : build;
        if (command.Is("msbuild")) return isRebuild ? msrebuild : msbuild;
        if (command.Is("restore")) return restore;
        // TODO: Assumptive (but true, for now?)
        if (command.Is("add"))     return installpackage; 
        if (command.Is("remove"))  return uninstallpackage;
        return default;
        
    }
}
