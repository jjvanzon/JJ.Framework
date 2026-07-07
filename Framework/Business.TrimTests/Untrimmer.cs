namespace JJ.Framework.Business.Legacy.TrimTests;

internal static class Untrimmer
{
    private const string MainAsm = "JJ.Framework.Business.Legacy";

    [NoTrim("_messages", typeof(ResultBaseAccessor))]
    [NoTrim("ExceptionMessage", $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("Stringify",        $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",  $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    public static void Untrim() { }
}
