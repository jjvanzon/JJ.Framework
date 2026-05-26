// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    
    [NoTrim(AllCtors,                       typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.CommandEnum), typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.Command),     typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.ID),          typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.Ver),         typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.Args),        typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.IsRebuild),   typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.FullArgs),    typeof(DotNetArgs))]
    [NoTrim(nameof(DebuggerDisplay),        typeof(DotNetArgs))]
    [NoTrim(nameof(DebuggerDisplay),        typeof(DotNetResult))]
    [NoTrim(nameof(DebuggerDisplay),        typeof(DotNetOptions))]
    [NoTrim("DEFAULT_TIME_OUT_SEC",         typeof(DotNetOptions))]
    [NoTrim("FormatArgs",        $"{MainAsm}.DotNetArgFormatter",   MainAsm)]
    [NoTrim("Enrich",            $"{MainAsm}.DotNetEnricher",       MainAsm)]
    [NoTrim("Log",               $"{MainAsm}.DotNetLogger",         MainAsm)]
    [NoTrim("Descriptor",        $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("Stringify",         $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",   $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("ExceptionMessage",  $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("CommandDescriptor", $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("IDVerDescriptor",   $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("ArgsDescriptor",    $"{MainAsm}.DiagnosticsFormatter", MainAsm)]

    public static void Untrim() { }
}
