namespace JJ.Framework.Compilation.Core;

internal static class DiagnosticsFormatter
{
    private const string DotNetArgsNull = $"<{nameof(DotNetArgs)}=null>";

    public static string Descriptor(DotNetArgs? args)
    {
        if (args == null) return DotNetArgsNull;

        string commandDescriptor = CommandDescriptor(args);
        string idVerDescriptor = IDVerDescriptor(args);
        string argsDescriptor = ArgsDescriptor(args);

        string sep1 = Has(commandDescriptor) && Has(idVerDescriptor) ? " " : "";
        string sep2 = Has(sep1) && Has(argsDescriptor) ? " | " : "";

        return commandDescriptor + sep1 + idVerDescriptor + sep2 + argsDescriptor;
    }

    private static string CommandDescriptor(DotNetArgs? args)
    {
        if (args == null) return DotNetArgsNull;
        
        return CommandDescriptor(args.CommandEnum, args.Command, args.IsRebuild);
    }

    private static string CommandDescriptor(DotNetCommandEnum @enum, string? command, bool isRebuild)
    {
        command ??= "";

        //string enumText = Coalesce(@enum, "");
        //string commandText = CommandRequired(enumText, command, isRebuild) ? command ?? "" : "";

        bool hasEnum = Has(@enum);
        bool includeCommand = IncludeCommand(@enum, command, isRebuild);
        bool reRequired = ReRequired(@enum, command, isRebuild);

        if (!hasEnum && !includeCommand && !reRequired) return "<no command>";
        if (!hasEnum && !includeCommand &&  reRequired) return "(re-)<no command>";
        if (!hasEnum &&  includeCommand && !reRequired) return command;
        if (!hasEnum &&  includeCommand &&  reRequired) return "(re)" + command;
        if ( hasEnum && !includeCommand && !reRequired) return $"{@enum}";
        if ( hasEnum && !includeCommand &&  reRequired) return "(re)" + @enum;
        if ( hasEnum &&  includeCommand && !reRequired) return $"{@enum} / {command}";
        if ( hasEnum &&  includeCommand &&  reRequired) return $"{@enum} / (re){command}";

        throw new Exception(
            $"No descriptor can be derived from combination of " +
            $"{new { @enum, command, isRebuild, hasEnum, hasCommand = includeCommand, reRequired }}"); // ncrunch: no coverage
    }

    private static bool ReRequired(DotNetCommandEnum @enum, string? command, bool isRebuild)
    {
        if (!isRebuild) return false;
        if (IsRe(@enum)) return false;
        return true;
    }
    
    private static bool IncludeCommand(DotNetCommandEnum @enum, string? command, bool isRebuild)
    {
        if (!Has(command)) return false;

        // Always include in case of inconsistencies.

        bool invalidReFlag = IsRe(@enum) != isRebuild;
        if (invalidReFlag) return true;

        bool unknownCommand = !command.In("build", "msbuild", "restore", "add", "remove");
        if (unknownCommand) return true;

        // Otherwise include when different
        string enumText = @enum.ToString();
        return !command.Is(enumText);
        
        //if (!Has(@enum)) return true;
        //if ($"re{command}".Is($"{@enum}")) return false;
        //return true;
    }

    //private static bool IsInconsistent

    private static bool IsRe(DotNetCommandEnum @enum) 
        => @enum is rebuild or msrebuild;

    private static string IDVerDescriptor(DotNetArgs? args)
    {
        if (args == null) return DotNetArgsNull;

        return IDVerDescriptor(args.ID, args.Ver);
    }

    private static string IDVerDescriptor(string? id, string? ver) 
        => $"{id} {ver}".Trim();

    private static string ArgsDescriptor(DotNetArgs? args)
    {
        if (args == null) return DotNetArgsNull;

        return ArgsDescriptor(args.Args, args.FullArgs);
    }

    private static string ArgsDescriptor(string? args, string? fullArgs)
    {
        args     = (args     ?? "").Trim();
        fullArgs = (fullArgs ?? "").Trim();

        if (fullArgs.Contains(args, OrdinalIgnoreCase))
        {
            return fullArgs;
        }

        string sep = Has(args) && Has(fullArgs) ? " | " : "";

        return args + sep + fullArgs;
    }
}
