namespace JJ.Framework.Business.Legacy.TrimTests;

internal static class Untrimmer
{
    [NoTrim("_messages", typeof(ResultBaseAccessor))]
    public static void Untrim() { }
}
