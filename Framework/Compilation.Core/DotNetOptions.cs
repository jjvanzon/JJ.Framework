namespace JJ.Framework.Compilation.Core;

public record struct DotNetOptions
{
    public DotNetOptions() { }

    public static DotNetOptions Default { get; } = new();

    public const int DEFAULT_TIME_OUT_SECONDS = 180;

    public string Dir { get; init; } = "";
    public string File { get; init; } = "";
    /// <summary> Typically "Release" or "Debug", and "" for default behavior. </summary>
    public string Configuration { get; init; } = "";
    public string Args { get; init; } = "";
    public bool AutoRestore { get; init; }
    public int TimeOutSec { get; init; } = DEFAULT_TIME_OUT_SECONDS;
}
