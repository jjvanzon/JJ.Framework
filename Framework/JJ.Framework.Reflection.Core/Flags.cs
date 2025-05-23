namespace JJ.Framework.Reflection.Core;

public enum MatchCaseFlag
{
    matchcase = 1
}

public abstract class NullFlag
{
    private NullFlag() { }
    public const NullFlag? nullable = null;
}