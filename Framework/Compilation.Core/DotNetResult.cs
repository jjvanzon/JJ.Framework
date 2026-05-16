namespace JJ.Framework.Compilation.Core;

public record DotNetResult
{
    public override string ToString() => Text;
    public static implicit operator string(DotNetResult? result) => $"{result}";

    public string Text { get; }

    public DotNetInfo    Info             { get; }
    public DotNetOptions Opt              { get; }
    public string        FullArgs         { get; }
    public int           ExitCode         { get; }
    public string        ErrorText        { get; }
    public string        OutputText       { get; }
    public string        TimeOutMessage   { get; }
    
    public bool          HasError         { get; }
    public bool          HasExitCode      { get; }
    public bool          HasErrorText     { get; }
    public bool          HasOutput        { get; }
    public bool          HasErrorInOutput { get; }
    public bool          HasTimeOut       { get; }

    internal DotNetResult(
        DotNetInfo info, DotNetOptions opt, string fullArgs, 
        int exitCode, string errorText, string outputText, string timeOutMessage)
    {
        Info = info;
        Opt = opt;
        FullArgs = fullArgs;
        ExitCode = exitCode;
        ErrorText = errorText;
        OutputText = outputText;
        TimeOutMessage = timeOutMessage;

        HasExitCode      = Has(exitCode);
        HasErrorText     = Has(errorText);
        HasOutput        = Has(outputText);
        HasErrorInOutput = outputText.Contains("[error]");
        HasTimeOut       = Has(timeOutMessage);
        HasError         = HasExitCode || HasErrorInOutput | HasTimeOut; // Don't consider error text, which has welcome messages and such in it these days.

        Text = Join(NewLine,
                    HasExitCode  ? $"Exit Code = {exitCode}" : "",
                    HasErrorText ? $"Error = {errorText}" : "",
                    HasOutput    ? $"Output = {outputText}" : "");
    }
}
