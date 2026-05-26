namespace JJ.Framework.Compilation.Core;

[DebuggerDisplay("{DebuggerDisplay}")]
public record DotNetResult
{
    public override string ToString() => Text;
    private string DebuggerDisplay => Text;
    public static implicit operator string(DotNetResult? result) => result?.Text ?? "";

    public string        Text             { get; }

    public DotNetOptions Opt              { get; }
    public DotNetArgs    Args             { get; }
    public int           ExitCode         { get; }
    public string        ErrorText        { get; }
    public string        OutputText       { get; }
    public string        TimeOutMessage   { get; }
    
    public bool          Successful       { get; }
    public bool          HasExitCode      { get; }
    public bool          HasErrorText     { get; }
    public bool          HasOutputText    { get; }
    public bool          HasErrorInOutput { get; }
    public bool          HasTimeOut       { get; }

    internal DotNetResult(
        DotNetOptions opt, DotNetArgs args,
        int exitCode, string errorText, string outputText, string timeOutMessage)
    {
        Args             = args;
        Opt              = opt;
        ExitCode         = exitCode;
        ErrorText        = errorText;
        OutputText       = outputText;
        TimeOutMessage   = timeOutMessage;

        HasExitCode      = Has(exitCode);
        HasErrorText     = Has(errorText);
        HasOutputText    = Has(outputText);
        HasErrorInOutput = outputText.Contains("[error]");
        HasTimeOut       = Has(timeOutMessage);
        bool hasError    = HasExitCode || HasErrorInOutput | HasTimeOut; // Don't consider error text, which has welcome messages and such in it these days.
        Successful       = !hasError;

        Text = Stringify(this);
        
        /*
        Text = Join(NewLine,
                    HasExitCode   ? $"Exit Code = {exitCode}" : "",
                    HasErrorText  ? $"Error = {errorText}" : "",
                    HasOutputText ? $"Output = {outputText}" : "");
        */
    }

    public void Assert()
    {
        if (Successful) return;
        throw new Exception(ExceptionMessage(this));
        /*
        throw new Exception(
            $"dotnet {Args} failed " +
            $"{new { HasExitCode, HasErrorText, HasErrorInOutput, HasTimeOut, Args.FullArgs }}: " +
            $"{TimeOutMessage} " +
            $"Exit code {ExitCode} {ErrorText} {OutputText}");
        */
    }

    private static string Stringify(DotNetResult result) => Descriptor(result, NewLine);
    private static string ExceptionMessage(DotNetResult result) => Descriptor(result, " ");
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
