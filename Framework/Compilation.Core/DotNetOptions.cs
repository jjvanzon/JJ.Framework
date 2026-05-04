namespace JJ.Framework.Compilation.Core;

public record struct DotNetOptions
{
    public DotNetOptions() { }

    public const int DEFAULT_TIME_OUT_SECONDS = 180;

    public string Dir { get; init; } = "";
    public string Args { get; init; } = "";
    public int TimeOutSec { get; init; } = DEFAULT_TIME_OUT_SECONDS;
}
