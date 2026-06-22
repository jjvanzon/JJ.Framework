namespace JJ.Framework.Compilation.Core.Primitives;

/// <inheritdoc cref="_dotnetoptions" />
[DebuggerDisplay("{DebuggerDisplay}")]
public readonly record struct DotNetOptions
{
    /// <inheritdoc cref="_tostring" />
    public override string ToString() => Stringify(this);
    private string DebuggerDisplay => DebuggerDisplay(this);

    /// <inheritdoc cref="_dotnetoptions" />
    public DotNetOptions() { }

    /// <inheritdoc cref="_nullaction" />
    public static readonly Action<string> NullAction = _ => { };
    /// <inheritdoc cref="_defaultoptions" />
    public static readonly DotNetOptions DefaultOptions = new();

    // File

    /// <inheritdoc cref="_dir" />
    public string          Dir             { get; init; } = "";
    /// <inheritdoc cref="_file" />
    public string          File            { get; init; } = "";

    // Build

    /// <inheritdoc cref="_buildconf" />
    public string          BuildConf       { get; init; } = "";
    /// <inheritdoc cref="_args" />
    public string          Args            { get; init; } = "";

    // Restore

    /// <inheritdoc cref="_autorestore" />
    public bool            AutoRestore     { get; init; }
    /// <inheritdoc cref="_parallelrestore" />
    public bool            ParallelRestore { get; init; }

    // Process

    /// <inheritdoc cref="_nodereuse" />
    public bool            NodeReuse       { get; init; }
    /// <inheritdoc cref="_timeoutsec" />
    public int             TimeOutSec      { get; init; } = 5 * 60;

    // Logging

    /// <inheritdoc cref="_verbosity" />
    public DotNetVerbosity Verbosity       { get; init; } = Normal;
    /// <inheritdoc cref="_logfile" />
    public string          LogFile         { get; init; } = "";
    /// <inheritdoc cref="_binlog" />
    public string          BinLog          { get; init; } = "";
    /// <inheritdoc cref="_logaction" />
    public Action<string>  LogAction       { get; init; } = NullAction;
}
