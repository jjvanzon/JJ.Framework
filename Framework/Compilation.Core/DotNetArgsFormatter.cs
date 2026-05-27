namespace JJ.Framework.Compilation.Core;

internal static class DotNetArgsFormatterExtensions
{
    public static string Stringify(this DotNetArgs? args) => DotNetArgsFormatter.Stringify(args);
    public static string DebuggerDisplay(this DotNetArgs? args) => DotNetArgsFormatter.DebuggerDisplay(args);
    public static string Descriptor(this DotNetArgs? args) => DotNetArgsFormatter.Descriptor(args);
}

internal static class DotNetArgsFormatter
{
    public static string Stringify(DotNetArgs? args)
    {
        string descriptor = Descriptor(args);
        string sep = Has(descriptor) ? " " : "";
        return nameof(DotNetArgs) + sep + descriptor;
    }

    public static string DebuggerDisplay(DotNetArgs? args)
    {
        var descriptor = Descriptor(args);
        descriptor = descriptor.Replace('"', '\'').Replace('\\', '/');
        string sep = Has(descriptor) ? " " : "";
        return "{" + nameof(DotNetArgs) + sep + descriptor + "}";
    }

    public static string Descriptor(DotNetArgs? args)
    {
        if (args == null) return "<null>";

        string commandDescriptor = CommandDescriptor(args);
        string idVerDescriptor = IDVerDescriptor(args);
        string argsDescriptor = ArgsDescriptor(args);

        // Cut away redundancies.
        if (argsDescriptor.StartsWith(commandDescriptor, OrdinalIgnoreCase))
        {
            commandDescriptor = "";
        }
        if (argsDescriptor.StartsWith(args.Command, OrdinalIgnoreCase))
        {
            commandDescriptor = commandDescriptor.CutRight(args.Command).CutRight(" / ");
        }
        if (Has(args.ID) && argsDescriptor.Contains(args.ID, OrdinalIgnoreCase))
        {
            idVerDescriptor = idVerDescriptor.Replace(args.ID, "").TrimStart();
        }
        if (Has(args.Ver) && argsDescriptor.Contains(args.Ver, OrdinalIgnoreCase))
        {
            idVerDescriptor = idVerDescriptor.Replace(args.Ver, "").TrimEnd();
        }

        string sep1 = Has(commandDescriptor) && Has(idVerDescriptor) ? " " : "";
        string sep2 = (Has(commandDescriptor) || Has(idVerDescriptor)) && Has(argsDescriptor) ? " | " : "";

        return commandDescriptor + sep1 + idVerDescriptor + sep2 + argsDescriptor;
    }

    // Command Descriptor

    private static string CommandDescriptor(DotNetArgs args) => CommandDescriptor(args.CommandEnum, args.Command, args.IsRebuild);
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

        bool commandCanBeRe = CanBeRe(command);
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
    }
    
    private static bool ReRequired(bool isRebuild, DotNetCommandEnum @enum, bool inconsistenciesDetected)
    {
        if (!Has(isRebuild)) return false;

        // Always include in case of inconsistencies.
        if (inconsistenciesDetected) return true;

        // Otherwise only include when not already implied by enum.
        return !IsRe(@enum);
    }

    private static bool IsRe(DotNetCommandEnum @enum) => @enum is rebuild or msrebuild;
    private static bool CanBeRe(string? command) => !Has(command) || command.In("build", "msbuild");

    // IDVerDescriptor

    private static string IDVerDescriptor(DotNetArgs args) => IDVerDescriptor(args.ID, args.Ver);
    private static string IDVerDescriptor(string? id, string? ver)
    {
        return $"{id} {ver}".Trim();
    }

    private static string ArgsDescriptor(DotNetArgs args) => ArgsDescriptor(args.Args, args.FullArgs);
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
