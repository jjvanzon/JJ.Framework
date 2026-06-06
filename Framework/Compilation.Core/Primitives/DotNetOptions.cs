namespace JJ.Framework.Compilation.Core.Primitives;

[DebuggerDisplay("{DebuggerDisplay}")]
public readonly record struct DotNetOptions
{
    public override string ToString() => Stringify(this);
    private string DebuggerDisplay => DebuggerDisplay(this);

    public DotNetOptions() { }

    public static readonly Action<string> NullAction = _ => { };
    public static readonly DotNetOptions DefaultOptions = new();

    // File

    public string          Dir             { get; init; } = "";
    public string          File            { get; init; } = "";

    // Build

    /// <summary> Build configuration. Typically "Release" or "Debug", and "" for default behavior. </summary>
    public string          BuildConf       { get; init; } = "";
    public string          Args            { get; init; } = "";

    // Restore

    public bool            AutoRestore     { get; init; }
    /// <summary>
    /// Many NuGet restores firing off at the same time,
    /// are unfortunately prone to time-outs and perhaps even dead-locks.
    /// Parallel restores will be disabled by default to prevent this.
    /// You can re-enabled it by setting ParallelRestore to true.
    /// </summary>
    public bool            ParallelRestore { get; init; }

    // TODO: NodeReuse an BinLog not supported as much as other options (in tests) like AutoRestore is.

    // Process

    /// <summary>
    /// Limits the amount of dotnet.exe processes spun up.
    /// If many compilations are run in parallel,
    /// NodeReuse = true might reuse too little dotnet.exe instances
    /// (bug after after Visual Studio 2026 update to 18.6.0 and 18.6.2.)
    /// Trying NodeReuse = false as a default for that reason.
    /// Set to true explicitly to restore original behavior.
    /// </summary>
    public bool            NodeReuse       { get; init; }
    public int             TimeOutSec      { get; init; } = 5 * 60;

    // Logging

    /// <summary>
    /// <para>Verbosity is passed to the build processes executed in this helper.</para>
    /// Plus:<br/>
    /// - <c>Diagnostic</c> or <c>Detailed</c> will log all build output.<br/>
    /// - <c>Normal</c> and <c>Minimal</c> will only check silently for errors internally.<br/>
    /// - <c>Quiet</c> won't work, because it'll swallow diagnostics used by the logic.
    /// </summary>
    public DotNetVerbosity Verbosity       { get; init; } = Normal;
    public string          LogFile         { get; init; } = "";
    public string          BinLog          { get; init; } = "";
    public Action<string>  LogAction       { get; init; } = NullAction;
}
