namespace JJ.Framework.Compilation.Core;

[DebuggerDisplay("{DebuggerDisplay}")]
public record DotNetResult
{
    private string DebuggerDisplay => DebuggerDisplay(this);
    public override string ToString() => Coalesce(Text, Stringify(this));
    public static implicit operator string(DotNetResult? result) => Coalesce(result?.Text, Stringify(result));

    public string        Text             { get; }

    public DotNetOptions Opt              { get; }
    public DotNetArgs    Args             { get; }
    public int           ExitCode         { get; }
    public string        ErrorText        { get; }
    public string        OutputText       { get; }
    
    public bool          Successful       { get; }
    public bool          HasExitCode      { get; }
    public bool          HasErrorText     { get; }
    public bool          HasOutputText    { get; }
    public bool          HasErrorInOutput { get; }
    public bool          HasTimeOut       { get; }

    internal DotNetResult(
        DotNetOptions opt, DotNetArgs args,
        int exitCode, string errorText, string outputText, bool hasTimeOut)
    {
        Args             = args;
        Opt              = opt;
        ExitCode         = exitCode;
        ErrorText        = errorText;
        OutputText       = outputText;

        HasExitCode      = Has(exitCode);
        HasErrorText     = Has(errorText);
        HasOutputText    = Has(outputText);
        HasErrorInOutput = outputText.Contains("[error]");
        HasTimeOut       = hasTimeOut;
        bool hasError    = HasExitCode || HasErrorInOutput | HasTimeOut; // Don't consider error text, which has welcome messages and such in it these days.
        Successful       = !hasError;

        Text = Stringify(this);
    }

    public void Assert()
    {
        if (Successful) return;
        throw new Exception(ExceptionMessage(this));
    }
}
