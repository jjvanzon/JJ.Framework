// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    [NoTrim(AllCtors,            $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("set_Command",       $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("set_CommandEnum",   $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("set_ID",            $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("set_Ver",           $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("set_Args",          $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("set_FullArgs",      $"{MainAsm}.DotNetArgs",           MainAsm)]
    [NoTrim("FormatArgs",        $"{MainAsm}.DotNetArgFormatter",   MainAsm)]
    [NoTrim("Enrich",            $"{MainAsm}.DotNetEnricher",       MainAsm)]
    [NoTrim("Log",               $"{MainAsm}.DotNetLogger",         MainAsm)]
    [NoTrim("CommandDescriptor", $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("IDVerDescriptor",   $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("ArgsDescriptor",    $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    public static void Untrim() { }
}
