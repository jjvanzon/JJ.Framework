namespace JJ.Framework.Compilation.Core.Formatters;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
internal static class DotNetArgsFormatterExtensions
{
    extension(DotNetArgs? args)
    {
        public string Stringify() => DotNetArgsFormatter.Stringify(args);
        public string DebuggerDisplay() => DotNetArgsFormatter.DebuggerDisplay(args);
        public string Descriptor() => DotNetArgsFormatter.Descriptor(args);
    }
}
// ReSharper restore UnusedType.Global
// ReSharper restore UnusedMember.Global

internal static class DotNetArgsFormatter
{
    // Combined Descriptors

    public static string Stringify(DotNetArgs? args)
    {
        string descriptor = Descriptor(args);
        string sep = Has(descriptor) ? " " : "";
        return nameof(DotNetArgs) + sep + descriptor;
    }

    public static string DebuggerDisplay(DotNetArgs? args)
    {
        var descriptor = Descriptor(args);
        descriptor = PrettifySeparators(descriptor);
        string sep = Has(descriptor) ? " " : "";
        return "{" + nameof(DotNetArgs) + sep + descriptor + "}";
    }

    public static string Descriptor(DotNetArgs? args)
    {
        if (args == null) return "<null>";

        string commandDescriptor = CommandDescriptor(args);
        string idVerDescriptor = IDVerDescriptor(args);
        string argPropsDescriptor = ArgPropsDescriptor(args);

        // Cut away redundancies.
        commandDescriptor = StripCommandDescriptor(commandDescriptor, args);
        idVerDescriptor = StripIDVerDescriptor(idVerDescriptor, args);

        string sep1 = Has(commandDescriptor) && Has(idVerDescriptor) ? " " : "";
        string sep2 = (Has(commandDescriptor) || Has(idVerDescriptor)) && Has(argPropsDescriptor) ? " | " : "";

        return commandDescriptor + sep1 + idVerDescriptor + sep2 + argPropsDescriptor;
    }

    // TODO: Might replace DotNetArgs with string(s).
    public static string StripIDVerDescriptor(string idVerDescriptor, DotNetArgs? args)
    {
        if (args == null) 
        {
            return idVerDescriptor;
        }
        if (args.Args.Has(args.ID))
        {
            idVerDescriptor = idVerDescriptor.Replace(args.ID, "").TrimStart();
        }
        if (args.FullArgs.Has(args.ID))
        {
            idVerDescriptor = idVerDescriptor.Replace(args.ID, "").TrimStart();
        }
        if (args.Args.Has(args.Ver))
        {
            idVerDescriptor = idVerDescriptor.Replace(args.Ver, "").TrimEnd();
        }
        if (args.FullArgs.Has(args.Ver))
        {
            idVerDescriptor = idVerDescriptor.Replace(args.Ver, "").TrimEnd();
        }

        return idVerDescriptor;
    }

    public static string StripCommandDescriptor(
        string commandDescriptor, DotNetArgs? args)
    {
        if (args == null) 
        {
            return commandDescriptor;
        }
   
        if (args.Args.LeftIs(commandDescriptor))
        {
            commandDescriptor = "";
        }

        if (args.FullArgs.LeftIs(commandDescriptor))
        {
            commandDescriptor = "";
        }

        if (args.Args.LeftIs(args.Command))
        {
            commandDescriptor = commandDescriptor.CutRight(args.Command).CutRight(" / ");
        }

        if (args.FullArgs.LeftIs(args.Command))
        {
            commandDescriptor = commandDescriptor.CutRight(args.Command).CutRight(" / ");
        }

        return commandDescriptor;
    }

    // Command Descriptor

    private const string DEFAULT_NO_COMMAND_INDICATOR = "<no command>";

    public static string CommandDescriptor(DotNetArgs args, string noCommandIndicator = DEFAULT_NO_COMMAND_INDICATOR) => CommandDescriptor(args.CommandEnum, args.Command, args.IsRebuild, noCommandIndicator);
    public static string CommandDescriptor(DotNetCommandEnum @enum, string? command, bool isRebuild, string noCommandIndicator = DEFAULT_NO_COMMAND_INDICATOR)
    {
        bool inconsistenciesDetected = IsInconsistent(@enum, command, isRebuild);
        bool enumRequired    = Has(@enum);
        bool commandRequired = CommandRequired(command, @enum, inconsistenciesDetected);
        bool reRequired      = ReRequired(isRebuild, @enum, inconsistenciesDetected);

        if (!enumRequired && !commandRequired && !reRequired) return noCommandIndicator;
        if (!enumRequired && !commandRequired &&  reRequired) return "(re-)" + noCommandIndicator;
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

    public static string IDVerDescriptor(DotNetArgs args) => IDVerDescriptor(args.ID, args.Ver);
    public static string IDVerDescriptor(string? id, string? ver)
    {
        return $"{id} {ver}".Trim();
    }

    // ArgPropsDescriptor

    public static string ArgPropsDescriptor(DotNetArgs args) => ArgPropsDescriptor(args.Args, args.FullArgs);
    public static string ArgPropsDescriptor(string? args, string? fullArgs)
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
