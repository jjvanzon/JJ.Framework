// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    private const string MainAsm = "JJ.Framework.Compilation.Core";

    [NoTrim(AllCtors,          $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("set_Command",     $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("set_CommandEnum", $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("set_Args",        $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("set_IsRebuild",   $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("set_ID",          $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("set_Ver",         $"{MainAsm}.DotNetInfo",       MainAsm)]
    [NoTrim("FormatArgs",      $"{MainAsm}.DotNetArgBuilder", MainAsm)]
    [NoTrim("Enrich",          $"{MainAsm}.DotNetEnricher",   MainAsm)]
    public static void Untrim() { }
}
