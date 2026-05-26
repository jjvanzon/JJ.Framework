namespace JJ.Framework.Compilation.Core;

internal static partial class DiagnosticsFormatter
{
    public static string Stringify(DotNetResult result) => Descriptor(result, NewLine);
    public static string ExceptionMessage(DotNetResult result) => Descriptor(result, " ");
    private static string Descriptor(DotNetResult result, string sep)
    {
        bool exitCodeWasAdded = false;
        bool dotNetWasAdded = false;

        string failurePart = "";
        if (result.HasTimeOut)
        {
            failurePart = "dotnet TIME OUT!";
            dotNetWasAdded = true;
        }
        else if (result.HasErrorInOutput)
        {
            failurePart = "dotnet ERROR!";
            dotNetWasAdded = true;
        }
        else if (result.HasExitCode)
        {
            failurePart = "dotnet EXIT CODE = " + result.ExitCode + "!";
            exitCodeWasAdded = true;
            dotNetWasAdded = true;
        }

        string dotNetPart = dotNetWasAdded ? "" : "dotnet ";
        
        string argsPart = DiagnosticsFormatter.Descriptor(result.Args, result.Opt, sep);

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
        
        string errorTextPart = "";
        if (result.HasErrorText)
        {
            if (result.Successful)
            {
                errorTextPart = $"stdErr ={sep}{result.ErrorText}";
            }
            else
            {
                errorTextPart = $"Error ={sep}{result.ErrorText}";
            }
        }
        
        string outputTextPart = "";
        if (result.HasOutputText)
        {
            outputTextPart = $"Output ={sep}{result.OutputText}";
        }

        string[] elements = 
        [
            failurePart,
            argsPart,
            timeOutPart,
            exitCodePart,
            errorTextPart,
            outputTextPart
        ];

        var descriptor = dotNetPart + Join(sep, elements.Where(FilledIn));
        return descriptor;
    }
}
