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
        string enumText = Coalesce(@enum, "");
        string commandText = !command.Is(enumText) ? command ?? "" : "";

        bool hasEnum = Has(@enum);
        bool hasCommand = Has(commandText);
        bool reRequired = isRebuild && !IsRe(@enum);

        if (!hasEnum && !hasCommand && !reRequired) return "<no command>";
        if (!hasEnum && !hasCommand &&  reRequired) return "(re-)<no command>";
        if (!hasEnum &&  hasCommand && !reRequired) return commandText;
        if (!hasEnum &&  hasCommand &&  reRequired) return "(re)" + commandText;
        if ( hasEnum && !hasCommand && !reRequired) return enumText;
        if ( hasEnum && !hasCommand &&  reRequired) return "(re)" + enumText;
        if ( hasEnum &&  hasCommand && !reRequired) return $"{enumText} / {commandText}";
        if ( hasEnum &&  hasCommand &&  reRequired) return $"{enumText} / (re){commandText}";

        throw new Exception(
            $"No descriptor can be derived from combination of " +
            $"{new { @enum, command, isRebuild, hasEnum, hasCommand, reRequired }}"); // ncrunch: no coverage
    }

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
