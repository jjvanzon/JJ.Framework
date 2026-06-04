namespace JJ.Framework.Compilation.Core.Formatters;

internal static class DotNetResultFormatterExtensions
{
    public static string Stringify(this DotNetResult? result) => DotNetResultFormatter.Stringify(result);
    public static string DebuggerDisplay(this DotNetResult? result) => DotNetResultFormatter.DebuggerDisplay(result);
    public static string ExceptionMessage(this DotNetResult? result) => DotNetResultFormatter.ExceptionMessage(result);
    public static string Descriptor(this DotNetResult? result, bool singleLine = false) => DotNetResultFormatter.Descriptor(result, singleLine);
}

internal static class DotNetResultFormatter
{
    public static string Stringify(DotNetResult? result) => Has(result?.Text) ? result.Text : Descriptor(result);
    public static string DebuggerDisplay(DotNetResult? result) => Descriptor(result, singleLine: true);
    public static string ExceptionMessage(DotNetResult? result) => Descriptor(result, singleLine: true);
    public static string Descriptor(DotNetResult? result, bool singleLine = false)
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
            failurePart = $"TIME OUT! after {result.Opt.TimeOutSec}s";
            //dotNetWasAdded = true;
        }
        else if (result.HasErrorInOutput)
        {
            failurePart = "ERROR!";
            //dotNetWasAdded = true;
        }
        else if (result.HasExitCode)
        {
            failurePart = "EXIT CODE " + result.ExitCode + "!";
            exitCodeWasAdded = true;
            //dotNetWasAdded = true;
        }

        string dotNetPart = dotNetWasAdded ? "" : "dotnet ";

        // TODO: Remove redundancies from opt when already in args.
        
        string argsPart = result.Args.FilledIn() ? result.Args.Descriptor() : "";
        string optPart = result.Opt.FilledIn() ? result.Opt.Descriptor() : "";

        string timeOutPart = "";
        //if (result.HasTimeOut)
        //{
        //    timeOutPart = $"after {result.Opt.TimeOutSec}s";
        //}
        
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
