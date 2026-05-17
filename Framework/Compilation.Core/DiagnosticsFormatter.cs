// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract

namespace JJ.Framework.Compilation.Core;

internal static class DiagnosticsFormatter
{
    public static string Descriptor(DotNetArgs args)
    {
        string commandDescriptor = CommandDescriptor(args);
        string idVerDescriptor = IDVerDescriptor(args);
        
        //args.Args       
        //args.FullArgs   
        throw new NotImplementedException();
    }

    private static string CommandDescriptor(DotNetArgs args) 
        => ReNoCommand(args.CommandEnum, args.Command, args.IsRebuild);

    private static string ReNoCommand(DotNetCommandEnum @enum, string command, bool isRebuild)
    {
        string enumText = Coalesce(@enum, "");
        string commandText = !command.Is(enumText) ? command : "";

        bool hasEnum = Has(@enum);
        bool hasCommand = Has(command);
        bool reRequired = isRebuild && !enumText.StartsWith("re");

        if (!hasEnum && !hasCommand && !reRequired) return "<no command>";
        if (!hasEnum && !hasCommand &&  reRequired) return "(re-)<no command>";
        if (!hasEnum &&  hasCommand && !reRequired) return commandText;
        if (!hasEnum &&  hasCommand &&  reRequired) return "(re)" + commandText;
        if ( hasEnum && !hasCommand && !reRequired) return enumText;
        if ( hasEnum && !hasCommand &&  reRequired) return "(re)" + enumText;
        if ( hasEnum &&  hasCommand && !reRequired) return $"{enumText}/{commandText}";
        if ( hasEnum &&  hasCommand &&  reRequired) return $"{enumText}/(re){commandText}";

        throw new Exception(
            $"No descriptor can be derived from combination of " +
            $"{new { @enum, command, isRebuild, hasEnum, hasCommand, reRequired }}"); // ncrunch: no coverage
    }

    // ReSharper disable once UnusedParameter.Local
    private static string IDVerDescriptor(DotNetArgs args) 
    {
        //args.ID
        //args.Ver

        throw new NotImplementedException();
    }
}
