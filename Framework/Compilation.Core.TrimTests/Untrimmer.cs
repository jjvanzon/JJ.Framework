// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    [NoTrim("Args",              $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("FullArgs",          $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("FormatArgs",        $"{MainAsm}.DotNetArgFormatter",   MainAsm)]
    [NoTrim("Enrich",            $"{MainAsm}.DotNetEnricher",       MainAsm)]
    [NoTrim("Log",               $"{MainAsm}.DotNetLogger",         MainAsm)]
    [NoTrim("CommandDescriptor", $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("IDVerDescriptor",   $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("ArgsDescriptor",    $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    public static void Untrim() { }
}
