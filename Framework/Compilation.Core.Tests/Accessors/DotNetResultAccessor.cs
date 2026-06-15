namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = Bases)]
internal class DotNetResultAccessor
{
    private readonly AccessorCore _accessor;
    
    public DotNetResultAccessor(
        DotNetOptions opt, DotNetArgs args,
        int exitCode, string errorText, string outputText, bool hasTimeOut)
    {
        _accessor = new(typeof(DotNetResult), opt, args, exitCode, errorText, outputText, hasTimeOut);
    }

    public DotNetResultAccessor(DotNetResult obj)
    {
        _accessor = new(obj, typeof(DotNetResult));
    }

    [return: NotNullIfNotNull(nameof(accessor))]
    public static implicit operator DotNetResult?(DotNetResultAccessor? accessor) => accessor?.Obj;

    public DotNetResult Obj => (DotNetResult)_accessor.Obj!;

    public string DebuggerDisplay => _accessor.Get<string>()!;
}

