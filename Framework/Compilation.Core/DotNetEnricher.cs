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
                           TryGetCommandEnum(args);
    }

    public static string FormatCommand(DotNetCommandEnum val) => val switch
    {
        build or rebuild => "build",
        msbuild or msrebuild => "msbuild",
        restore => "restore",
        // pre-.NET 10 style for compatibilty.
        installpackage => "add package",
        uninstallpackage => "remove package",
        _ => ""
    };

    public static DotNetCommandEnum TryGetCommandEnum(DotNetArgs args)
    {
        if (Is(args, "build "        )) return args.IsRebuild ? rebuild : build;
        if (Is(args, "msbuild"       )) return args.IsRebuild ? msrebuild : msbuild;
        if (Is(args, "restore"       )) return restore;
        if (Is(args, "add package"   )) return installpackage;
        if (Is(args, "remove package")) return uninstallpackage;
        // New .NET 10 style.
        if (Is(args, "package add"   )) return installpackage; 
        if (Is(args, "package remove")) return uninstallpackage;

        return default;
    }

    private static bool Is(DotNetArgs dotNetArgs, string commandToMatch)
    {
        string command = dotNetArgs.Command.TrimStart();
        string args = dotNetArgs.Args.TrimStart();

        if (command.Is(commandToMatch)) return true;
        if (command.StartsWith(commandToMatch + ' ', OrdinalIgnoreCase)) return true;
        if (!Has(command) && args.StartsWith(commandToMatch + ' ', OrdinalIgnoreCase)) return true;

        return false;
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
