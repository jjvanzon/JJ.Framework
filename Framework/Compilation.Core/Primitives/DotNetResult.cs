namespace JJ.Framework.Compilation.Core.Primitives;

/// <inheritdoc cref="_dotnetresult" />
[DebuggerDisplay("{DebuggerDisplay}")]
public record DotNetResult
{
    private string DebuggerDisplay => DebuggerDisplay(this);

    /// <inheritdoc cref="_text" />
    public override string ToString() => Coalesce(Text, Stringify(this));
    /// <inheritdoc cref="_text" />
    public static implicit operator string(DotNetResult? result) => Coalesce(result?.Text, Stringify(result));
    /// <inheritdoc cref="_text" />
    public string        Text             { get; }

    /// <inheritdoc cref="_dotnetoptions" />
    public DotNetOptions Opt              { get; }
    /// <inheritdoc cref="_dotnetargs" />
    public DotNetArgs    Args             { get; }
    /// <inheritdoc cref="_exitcode" />
    public int           ExitCode         { get; }
    /// <inheritdoc cref="_errortext" />
    public string        ErrorText        { get; }
    /// <inheritdoc cref="_outputtext" />
    public string        OutputText       { get; }

    /// <inheritdoc cref="_successful" />
    public bool          Successful       { get; }
    /// <inheritdoc cref="_hasexitcode" />
    public bool          HasExitCode      { get; }
    /// <inheritdoc cref="_haserrortext" />
    public bool          HasErrorText     { get; }
    /// <inheritdoc cref="_hasoutputtext" />
    public bool          HasOutputText    { get; }
    /// <inheritdoc cref="_hasererrorinoutput" />
    public bool          HasErrorInOutput { get; }
    /// <inheritdoc cref="_hastimeout" />
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

    /// <inheritdoc cref="_assert" />
    public void Assert()
    {
        if (Successful) return;
        throw new Exception(ExceptionMessage(this));
    }
}
