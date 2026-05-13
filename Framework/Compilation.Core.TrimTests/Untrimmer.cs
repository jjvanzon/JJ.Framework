// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";

    [NoTrim(AllCtors,      $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("Command",     $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("CommandEnum", $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("Args",        $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("IsRebuild",   $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("ID",          $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("Ver",         $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("FormatArgs",  $"{MainAsm}.DotNetArgBuilder", MainAsm)]
    [NoTrim("Enrich",      $"{MainAsm}.DotNetEnricher",   MainAsm)]
    [NoTrim("Log",         $"{MainAsm}.DotNetLogger",     MainAsm)]
    public static void Untrim() { }
}
