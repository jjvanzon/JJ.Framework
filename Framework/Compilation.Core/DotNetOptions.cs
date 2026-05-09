namespace JJ.Framework.Compilation.Core;

public record struct DotNetOptions
{
    public DotNetOptions() { }

    private const int DEFAULT_TIME_OUT_SEC = 180;
    internal static readonly Action<string> NullLog = _ => { };

    //public static DotNetOptions DefaultOptions { get; } = new();

    public string          Dir         { get; init; } = "";
    public string          File        { get; init; } = "";
    /// <summary> Build configuration. Typically "Release" or "Debug", and "" for default behavior. </summary>
    public string          BuildConf   { get; init; } = "";
    public string          Args        { get; init; } = "";
    /// <summary>
    /// <para>Verbosity is passed to the build processes executed in this helper.</para>
    /// Plus:<br/>
    /// - <c>Diagnostic</c> or <c>Detailed</c> will log all build output.<br/>
    /// - <c>Normal</c> and <c>Minimal</c> will only check silently for errors internally.<br/>
    /// - <c>Quiet</c> won't work, because it'll swallow diagnostics used by the logic.
    /// </summary>
    public DotNetVerbosity Verbosity   { get; init; }
    public bool            AutoRestore { get; init; }
    public int             TimeOutSec  { get; init; } = DEFAULT_TIME_OUT_SEC;
    public Action<string>  Log         { get; init; } = NullLog;
}
