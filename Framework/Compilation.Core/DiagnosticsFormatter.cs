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
        bool hasEnum = Has(args.CommandEnum);
        bool hasCommand = Has(args.Command);

        string enumText = Coalesce(args.CommandEnum, "");
        string isRebuildText = args.IsRebuild ? "(re)" : "";
        string commandTrim = args.Command?.Trim() ?? "";

        bool commandsEqual = enumText.Is(commandTrim);

        if (!commandsEqual)
        {
            if (args.IsRebuild)
            {
                return enumText + "/(re)" + commandTrim;
            }
            else
            {
                return enumText + "/" + commandTrim;
            }
        }
        else
        {
            if (args.IsRebuild)
            {
                if (HasRe(enumText))
                {
                    return enumText;
                }
                else
                {
                    return isRebuildText + enumText;
                }
            }
        }

        throw new NotImplementedException();
    }

    private static string FormatCommandTextEnumRe(string enumText, string command) => $"{enumText}/(re){command}";

    private static string FormatCommandRe(string command) => $"(re){command}";

    private static string FormatCommandEnumRe(string enumText)
    {
        if (HasRe(enumText))
        {
            return enumText;
        }
        else
        {
            return $"(re){enumText}";
        }
    }

    private static bool HasRe(string enumText) => enumText.StartsWith("re");

    // ReSharper disable once UnusedParameter.Local
    private static string IDVerDescriptor(DotNetArgs args) 
    {
        
        //args.ID
        //args.Ver        

        throw new NotImplementedException();
    }
}
