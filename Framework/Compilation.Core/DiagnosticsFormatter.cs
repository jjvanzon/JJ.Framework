namespace JJ.Framework.Compilation.Core;

internal static class DiagnosticsFormatter
{
    // Args Descriptor

    private const string DotNetArgsNull = $"<{nameof(DotNetArgs)}=null>";

    public static string Descriptor(DotNetArgs? args)
    {
        if (args == null) return DotNetArgsNull;

        string commandDescriptor = CommandDescriptor(args);
        string idVerDescriptor = IDVerDescriptor(args);
        string argsDescriptor = ArgsDescriptor(args);

        string sep1 = Has(commandDescriptor) && Has(idVerDescriptor) ? " " : "";
        string sep2 = (Has(commandDescriptor) || Has(idVerDescriptor)) && Has(argsDescriptor) ? " | " : "";

        return commandDescriptor + sep1 + idVerDescriptor + sep2 + argsDescriptor;
    }

    // Command Descriptor

    private static string CommandDescriptor(DotNetArgs? args)
    {
        if (args == null) return DotNetArgsNull;
        
        return CommandDescriptor(args.CommandEnum, args.Command, args.IsRebuild);
    }

    private static string CommandDescriptor(DotNetCommandEnum @enum, string? command, bool isRebuild)
    {
        bool inconsistenciesDetected = IsInconsistent(@enum, command, isRebuild);
        bool enumRequired    = Has(@enum);
        bool commandRequired = CommandRequired(command, @enum, inconsistenciesDetected);
        bool reRequired      = ReRequired(isRebuild, @enum, inconsistenciesDetected);

        if (!enumRequired && !commandRequired && !reRequired) return "<no command>";
        if (!enumRequired && !commandRequired &&  reRequired) return "(re-)<no command>";
        if (!enumRequired &&  commandRequired && !reRequired) return command ?? "";
        if (!enumRequired &&  commandRequired &&  reRequired) return "(re)" + command;
        if ( enumRequired && !commandRequired && !reRequired) return $"{@enum}";
        if ( enumRequired && !commandRequired &&  reRequired) return "(re)" + @enum;
        if ( enumRequired &&  commandRequired && !reRequired) return $"{@enum} / {command}";
        if ( enumRequired &&  commandRequired &&  reRequired) return $"{@enum} / (re){command}";

        throw new Exception( // ncrunch: no coverage
            $"No descriptor can be derived from combination of " +
            $"{new { @enum, command, isRebuild, enumRequired, commandRequired, reRequired }}");
    }
    
    private static bool IsInconsistent(DotNetCommandEnum @enum, string? command, bool isRebuild)
    {
        bool enumIsRe = IsRe(@enum);
        if (enumIsRe != isRebuild) return true;

        bool commandCanBeRe = CanBeRebuild(command);
        if (enumIsRe && !commandCanBeRe) return true;

        string[] knownCommands = [ "build", "msbuild", "restore", "add", "remove" ];
        bool commandIsUnknown = Has(command) && !command.In(knownCommands);
        if (commandIsUnknown) return true;

        bool commandIsMs = command.Is("msbuild");
        bool enumIsMs = @enum is msbuild or msrebuild;
        bool msMismatch = Has(command) && Has(@enum) && commandIsMs != enumIsMs;
        if (msMismatch) return true;

        return false;
    }

    private static bool CommandRequired(string? command, DotNetCommandEnum @enum, bool inconsistenciesDetected)
    {
        if (!Has(command)) return false;

        // Always include in case of inconsistencies.
        if (inconsistenciesDetected) return true;

        // Otherwise include when different
        string enumText = @enum.ToString();
        return !command.Is(enumText);
        
        //if (!Has(@enum)) return true;
        //return true;
    }
    
    private static bool ReRequired(bool isRebuild, DotNetCommandEnum @enum, bool inconsistenciesDetected)
    {
        if (!Has(isRebuild)) return false;

        // Always include in case of inconsistencies.
        if (inconsistenciesDetected) return true;

        // Otherwise only include when not already implied by enum.
        if (IsRe(@enum)) return false;
        return true;
    }

    private static bool IsRe(DotNetCommandEnum @enum) => @enum is rebuild or msrebuild;
    private static bool CanBeRebuild(string? command) => !Has(command) || command.In("build", "msbuild");

    // IDVerDescriptor

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
