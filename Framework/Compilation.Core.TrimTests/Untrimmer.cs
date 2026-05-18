// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    [NoTrim(AllCtors,            typeof(DotNetArgs))]
    [NoTrim("set_CommandEnum",   typeof(DotNetArgs))]
    [NoTrim("set_Command",       typeof(DotNetArgs))]
    [NoTrim("set_ID",            typeof(DotNetArgs))]
    [NoTrim("set_Ver",           typeof(DotNetArgs))]
    [NoTrim("set_Args",          typeof(DotNetArgs))]
    [NoTrim("set_IsRebuild",     typeof(DotNetArgs))]
    [NoTrim("set_FullArgs",      typeof(DotNetArgs))]
    [NoTrim("FormatArgs",        $"{MainAsm}.DotNetArgFormatter",   MainAsm)]
    [NoTrim("Enrich",            $"{MainAsm}.DotNetEnricher",       MainAsm)]
    [NoTrim("Log",               $"{MainAsm}.DotNetLogger",         MainAsm)]
    [NoTrim("CommandDescriptor", $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("IDVerDescriptor",   $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("ArgsDescriptor",    $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    public static void Untrim() { }
}
