namespace JJ.Framework.Compilation.Core;

internal static partial class DiagnosticsFormatter
{
    public static string Stringify(DotNetResult? result) => Has(result?.Text) ? result.Text : Descriptor(result);
    public static string DebuggerDisplay(DotNetResult? result) => Descriptor(result, singleLine: true);
    public static string ExceptionMessage(DotNetResult? result) => Descriptor(result, singleLine: true);
    private static string Descriptor(DotNetResult? result, bool singleLine = false)
    {
        string sep = singleLine ? " | " : NewLine;

        if (result == null) return nameof(DotNetResult) + " null";
        if (!Has(result)) return nameof(DotNetResult) + " empty";
        //if (Has(result.Text)) return result.Text;

        bool exitCodeWasAdded = false;
        bool dotNetWasAdded = false;

        string failurePart = "";
        if (result.HasTimeOut)
        {
            //failurePart = "TIME OUT!";
            //dotNetWasAdded = true;
        }
        else if (result.HasErrorInOutput)
        {
            failurePart = "ERROR!";
            //dotNetWasAdded = true;
        }
        else if (result.HasExitCode)
        {
            failurePart = "EXIT CODE = " + result.ExitCode + "!";
            exitCodeWasAdded = true;
            //dotNetWasAdded = true;
        }

        string dotNetPart = dotNetWasAdded ? "" : "dotnet ";

        // TODO: Remove redundancies from opt when already in args.
        
        string argsPart = result.Args.FilledIn() ? Descriptor(result.Args) : "";
        string optPart = result.Opt.FilledIn() ? Descriptor(result.Opt) : "";
        //string argsPart = $"{Descriptor(result.Args)}{sep}{Descriptor(result.Opt)}";

        string timeOutPart = "";
        if (result.HasTimeOut)
        {
            timeOutPart = result.TimeOutMessage;
        }
        
        string exitCodePart = "";
        if (result.HasExitCode && !exitCodeWasAdded)
        {
            exitCodePart = "ExitCode = " + result.ExitCode;
        }
        
        string sep2 = singleLine ? " " : NewLine;

        string errorTextPart = "";
        if (result.HasErrorText)
        {
            if (result.Successful)
            {
                errorTextPart = $"stdErr:{sep2}{result.ErrorText}";
            }
            else
            {
                errorTextPart = $"Error:{sep2}{result.ErrorText}";
            }
        }
        
        string outputTextPart = "";
        if (result.HasOutputText)
        {
            outputTextPart = $"Output:{sep2}{result.OutputText}";
        }

        string[] elements = 
        [
            failurePart,
            argsPart,
            optPart,
            timeOutPart,
            exitCodePart,
            errorTextPart,
            outputTextPart
        ];

        var descriptor = dotNetPart + Join(sep, elements.Where(FilledIn));
        return descriptor;
    }
}
