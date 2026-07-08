namespace JJ.Framework.Business;

/// <inheritdoc cref="_voidresult" />
[Obsolete(ObsoleteMesage)]
public class VoidResult : Result
{ 
    private const string ObsoleteMesage = "Use Result instead.";

    /// <inheritdoc cref="_voidresult" />
    [Obsolete(ObsoleteMesage)]
    public VoidResult() { }
    /// <inheritdoc cref="_voidresult" />
    [Obsolete(ObsoleteMesage)]
    public VoidResult(bool success) : base(success) { }
    /// <inheritdoc cref="_voidresult" />
    [Obsolete(ObsoleteMesage)]
    public VoidResult(params IEnumerable<string> messages) : base(messages) { }
    /// <inheritdoc cref="_voidresult" />
    [Obsolete(ObsoleteMesage)]
    public VoidResult(IEnumerable<string> messages, bool success) : base(messages, success) { }
    /// <inheritdoc cref="_voidresult" />
    [Obsolete(ObsoleteMesage)]
    public VoidResult(bool success, params IEnumerable<string> messages) : base(success, messages) { }
}