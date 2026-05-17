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
    {
        string enumText = Coalesce(args.CommandEnum, "");
        string commandText = !args.Command.Is(enumText) ? args.Command : "";

        bool hasEnum = Has(args.CommandEnum);
        bool hasCommand = Has(args.Command);
        bool reRequired = args.IsRebuild && !enumText.StartsWith("re");

        if ( hasEnum &&  hasCommand &&  reRequired) return $"{enumText}/(re){commandText}";
        if ( hasEnum &&  hasCommand && !reRequired) return $"{enumText}/{commandText}";
        if ( hasEnum && !hasCommand &&  reRequired) return $"(re){enumText}";
        if ( hasEnum && !hasCommand && !reRequired) return enumText;
        if (!hasEnum &&  hasCommand &&  reRequired) return $"(re){commandText}";
        if (!hasEnum &&  hasCommand && !reRequired) return commandText;
        if (!hasEnum && !hasCommand &&  reRequired) return "(re-)<no command>";
        if (!hasEnum && !hasCommand && !reRequired) return "<no command>";

        throw new Exception(
            $"No descriptor can be derived from combination of " +
            $"{new { args.CommandEnum, args.Command, args.IsRebuild, hasEnum, hasCommand, reRequired }}"); // ncrunch: no coverage
    }

    // ReSharper disable once UnusedParameter.Local
    private static string IDVerDescriptor(DotNetArgs args) 
    {
        
        //args.ID
        //args.Ver        

        throw new NotImplementedException();
    }
}
