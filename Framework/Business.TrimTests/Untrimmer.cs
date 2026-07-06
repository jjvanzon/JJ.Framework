namespace JJ.Framework.Business.Legacy.TrimTests;

internal static class Untrimmer
{
    private const string MainAsm = "JJ.Framework.Business.Legacy";

    [NoTrim("_messages", typeof(ResultBaseAccessor))]
    [NoTrim("ExceptionMessage", typeof(DiagnosticsFormatterAccessor))]
    [NoTrim("ExceptionMessage", $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    public static void Untrim() { }
}
