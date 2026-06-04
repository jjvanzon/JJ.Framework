namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = Bases)]
internal class DotNetResultAccessor
{
    private readonly AccessorCore _accessor;

    // Every constructor argument made optional, for better overview in the tests.

    private static readonly DotNetArgs DefaultArgs = new DotNetArgsAccessor().Obj;

    public DotNetResultAccessor(
        DotNetOptions opt = default,
        DotNetArgs? args = null,
        int exitCode = 0,
        string errorText = "",
        string outputText = "",
        bool hasTimeOut = false)
        => _accessor = new(typeof(DotNetResult), Coalesce(opt, DefaultOptions), args ?? DefaultArgs, exitCode, errorText, outputText, hasTimeOut);

    public DotNetResult Obj => (DotNetResult)_accessor.Obj!;

    public string DebuggerDisplay => _accessor.Get<string>()!;

}

