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
        string commandTrim = args.Command?.Trim() ?? "";

        bool commandsEqual = enumText.Is(commandTrim);
        if (commandsEqual) commandTrim = "";

        bool hasEnum = Has(args.CommandEnum);
        bool hasCommand = Has(args.Command);

        bool enumHasRe = HasRe(enumText);
        bool reRequired = !enumHasRe && args.IsRebuild;

        if (hasEnum && hasCommand && reRequired)
        {
            return FormatCommandEnumTextRe(enumText, commandTrim);
        }
        if (hasEnum && hasCommand && !reRequired)
        {
            return FormatCommandEnumText(enumText, commandTrim);
        }
        if (hasEnum && !hasCommand && reRequired)
        {
            return FormatCommandEnumRe(enumText);
        }
        if (hasEnum && !hasCommand && !reRequired)
        {
            return FormatCommandEnum(enumText);
        }
        if (!hasEnum && hasCommand && reRequired)
        {
            return FormatCommandTextRe(commandTrim);
        }
        if (!hasEnum && hasCommand && !reRequired)
        {
            return FormatCommandText(commandTrim);
        }
        if (!hasEnum && !hasCommand && reRequired)
        {
            return FormatNoCommandRe();
        }
        if (!hasEnum && !hasCommand && !reRequired)
        {
            return FormatNoCommand();
        }

        /*if (hasCommand)
        {
            if (args.IsRebuild)
            {
                if (HasRe(enumText))
                {
                    return enumText;
                }
                else
                {
                    return (args.IsRebuild ? "(re)" : "") + enumText;
                }
            }
        }
        else
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
        */

        throw new NotImplementedException();
    }

    private static string FormatNoCommand() 
        => "<no command>";

    private static string FormatNoCommandRe()
        => "(re-)<no command>";

    private static string FormatCommandText(string command) 
        => command;

    private static string FormatCommandEnum(string enumText) 
        => enumText;

    private static string FormatCommandEnumText(string enumText, string command) 
        => $"{enumText}/{command}";

    private static bool HasRe(string enumText) 
        => enumText.StartsWith("re");

    private static string FormatCommandTextRe(string command) 
        => $"(re){command}";

    private static string FormatCommandEnumRe(string enumText)
        => !HasRe(enumText) ? $"(re){enumText}" : enumText;

    private static string FormatCommandEnumTextRe(string enumText, string command) 
        => $"{enumText}/(re){command}";

    // ReSharper disable once UnusedParameter.Local
    private static string IDVerDescriptor(DotNetArgs args) 
    {
        
        //args.ID
        //args.Ver        

        throw new NotImplementedException();
    }
}
